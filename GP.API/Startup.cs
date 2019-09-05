using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using Serilog;
using GP.API.Models;
using GP.API.Entities;
using GP.API.Services;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.Dynamics.GP.eConnect.Serialization;
using GP.API.Middleware;

namespace GP.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .WriteTo.LiterateConsole()
                .CreateLogger();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            //services.AddMvcCore()
            //    .AddApiExplorer();
                //.AddJsonFormatters();

            
            //Get our custom configuration section from appsettings.json
            services.Configure<APIConfig>(options => Configuration.GetSection("APIConfig").Bind(options));

            //Retrieve SQL connection info from config in appsettings
            var config = Configuration.GetSection("APIConfig").Get<APIConfig>();
            string gpServer = config.GPServer;
            string gpCompanyDB = config.GPCompanyDB;
            string gpSystemDB = config.GPSystemDB;

            //Build our connection strings
            var connectionStringGP = $@"Server={gpServer};Database={gpCompanyDB};Trusted_Connection=True;";
            var connectionStringGPSystem = $@"Server={gpServer};Database={gpSystemDB};Trusted_Connection=True;";

            //Setup our database context
            services.AddDbContext<GPContext>(o => o.UseSqlServer(connectionStringGP));
            services.AddDbContext<GPSysContext>(o => o.UseSqlServer(connectionStringGPSystem));
            
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAPInvoiceRepository, APInvoiceRepository>();
            services.AddScoped<IAPImportInvoice, APImportInvoice>();
            services.AddScoped<ISOPOrderRepository, SOPOrderRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<IVendorAddressRepository, VendorAddressRepository>();
            services.AddScoped<IImportVendor, ImportVendor>();

            //Configure Swashbuckle / Swagger
            services.AddSwaggerGen(options =>
            {
                options.DocInclusionPredicate((version, apiDescription) =>
                {
                    var values = apiDescription.RelativePath
                        .Split('/')
                        .Select(v => v.Replace("v{version}", version));
                    //.Skip(1);
                    
                    apiDescription.RelativePath = string.Join("/", values);
                    //apiDescription.RelativePath = version + "/" + string.Join("/", values);

                    var versionParameter = apiDescription.ParameterDescriptions
                        .SingleOrDefault(p => p.Name == "version");

                    if (versionParameter != null)
                        apiDescription.ParameterDescriptions.Remove(versionParameter);

                    return true;
                });

                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = $"GP Web API v1"
                });

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime, IOptions<APIConfig> config)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration
            //Read custom config file for private keys
            string keyFileName = config.Value.KeyFile;
            var builder = new ConfigurationBuilder().AddJsonFile(keyFileName);
            IConfigurationRoot KeyConfig = builder.Build();
            config.Value.HMACSecret = KeyConfig["HMACSecret"];

            APIController.Instance.APIModel.APIConfig = config.Value;

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ItemEntity, ItemDto>();
                cfg.CreateMap<ItemSiteEntity, ItemSiteDto>();

                cfg.CreateMap<CustomerEntity, CustomerDto>();
                cfg.CreateMap<CustomerAddressEntity, CustomerAddressDto>();

                cfg.CreateMap<Entities.SOPWorkHeader, Models.SOPWorkHeaderDto>();
                cfg.CreateMap<Entities.SOPWorkLine, Models.SOPWorkLineDto>();
                
                cfg.CreateMap<Entities.SOPHistHeader, Models.SOPHistHeaderDto>();
                cfg.CreateMap<Entities.SOPHistLine, Models.SOPHistLineDto>();
                cfg.CreateMap<Entities.SOPTracking, Models.SOPTrackingDto>();

                cfg.CreateMap<VendorEntity, VendorSQLDto>();
                cfg.CreateMap<VendorAddressEntity, VendorAddressSQLDto>();
                cfg.CreateMap<Models.VendorECDto, taUpdateCreateVendorRcd>();

                cfg.CreateMap<EFTInfoEntity, EFTInfoDto>();
                cfg.CreateMap<EFTInfoCreateDto, EFTInfoDto>()
                    .ForAllMembers(opt => opt.ReplaceNullOrEmptyStringProperties(string.Empty));

                cfg.CreateMap<EFTInfoDto, EFTInfoDto>()
                    .ForAllMembers(opt => opt.ReplaceNullOrEmptyStringProperties(string.Empty));

                cfg.CreateMap<PMOpenEntity, PMOpenDto>()
                    .ForAllMembers(opt => opt.ReplaceNullOrEmptyStringProperties(string.Empty));

                cfg.CreateMap<APInvoiceECDto, taPMTransactionInsert>()
                    .ForAllMembers(opt => opt.ReplaceNullOrEmptyStringProperties(string.Empty));
                
                //Trim strings
                cfg.CreateMap<string, string>().ConvertUsing(str => (str ?? string.Empty).Trim());
            });

            
            //Use Serilog instead of default logging
            loggerFactory.AddSerilog();
            // Ensure any buffered events are sent at shutdown
            appLifetime.ApplicationStopped.Register(Log.CloseAndFlush);

            //Use middleware to make IP address available
            app.UseMiddleware<RemoteIpAddressLoggingMiddleware>();

            app.UseMiddleware<RequestHMACMiddleware>();


            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "GP Web API v1");
                //options.SwaggerEndpoint("/swagger/v2/swagger.json", ""GP Web API v2");

            });
        }
    }
}

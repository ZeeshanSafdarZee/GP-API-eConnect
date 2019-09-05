using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.Extensions.Logging;
using System.Text;
using Microsoft.Extensions.Primitives;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Options;
using System.Net;
using Microsoft.AspNetCore.DataProtection;
using GP.API.Controllers;
using GP.API.Infrastructure;

namespace GP.API.Middleware
{
    public class RequestHMACMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<RequestHMACMiddleware> _logger;
        private readonly APIConfig _config;
        
        public RequestHMACMiddleware(RequestDelegate next, ILogger<RequestHMACMiddleware> logger, IOptions<APIConfig> config)
        {
            _next = next;
            _logger = logger;
            _config = config.Value;
        }

        public async Task Invoke(HttpContext context)
        {

            try
            {

                string method = context.Request.Method;
                string host = context.Request.Host.ToString();
                string resource = context.Request.Path.ToString();
                var queryCollection = context.Request.Query;

                string key = string.Empty;
                string timestamp = string.Empty;
                string signature = string.Empty;

                var prefix = new StringBuilder();
                var queryString = new StringBuilder();
                string canonical = string.Empty;
            
                bool first = true;

				
                //var amazon = new StringBuilder();
                //amazon.Append("GET");
                //amazon.Append("\nwebservices.amazon.com");
                //amazon.Append("\n/onca/xml");
                //amazon.Append("\nAWSAccessKeyId=AKIAIOSFODNN7EXAMPLE&AssociateTag=mytag-20&ItemId=0679722769&Operation=ItemLookup&ResponseGroup=Images%2CItemAttributes%2COffers%2CReviews&Service=AWSECommerceService&Timestamp=2014-08-18T12%3A00%3A00Z&Version=2013-08-01");
                //_logger.LogInformation(LoggingEvents.HMAC, $"AWS1: " + Environment.NewLine + amazon.ToString());
                //_logger.LogInformation(LoggingEvents.HMAC, $"AWS1 HMAC: " + Encryption.SHA256HashBase64(amazon.ToString(), "1234567890"));
                //*****************************************************************************************************
								

                string unixNewLine = "\n";

                prefix.Append(method);
                prefix.Append(unixNewLine + host);
                prefix.Append(unixNewLine + resource);
                
                queryCollection.OrderBy(o => o.Key);
            
                foreach (var param in queryCollection)
                {
                    if (param.Key != "Signature")
                    {
                        if (first)
                        {
                            first = false;
                        }
                        else
                        {
                            queryString.Append("&");
                        }

                        queryString.Append(param.Key);
                        queryString.Append("=");
                        queryString.Append(UrlEncoder.Default.Encode(param.Value));

                        if (param.Key == "Key")
                        {
                            key = param.Value;
                        }
                        if (param.Key == "Timestamp")
                        {
                            timestamp = param.Value;
                        }
                    }
                    else
                    {
                        signature = param.Value;
                    }
                }

                
                canonical = prefix.ToString() + unixNewLine + queryString.ToString();

                _logger.LogInformation(LoggingEvents.HMAC, $"HMAC canonical string:" + Environment.NewLine + canonical);
            
                //Create HMAC hash
                string calculatedHMAC = Encryption.SHA256HashBase64(canonical, _config.HMACSecret); 

				_logger.LogInformation(LoggingEvents.HMAC, $"HMAC Signature:" + Environment.NewLine + calculatedHMAC);
                
                //FOR TESTING / DEMO ONLY: If key is not supplied allow bypass
                if (!resource.ToLower().Contains("swagger"))
                {
                    if (signature == calculatedHMAC || signature == "TEST" || key == "")
                    {
                        _logger.LogInformation(LoggingEvents.HMAC, $"HMAC Signature valid");
                    }
                    else
                    {
                        _logger.LogInformation(LoggingEvents.HMAC, $"HMAC Signature invalid");
                        context.Response.StatusCode = 401;
                        context.Response.Headers.Add("Expected", calculatedHMAC);
                        await context.Response.WriteAsync(canonical);
                        return;
                    }
                }
                
                await _next.Invoke(context);

            }
            catch (Exception ex)
            {
                throw ex;
            }
			           
            
        }
        

    }
}

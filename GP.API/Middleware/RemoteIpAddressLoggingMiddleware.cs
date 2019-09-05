using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Middleware
{
    public class RemoteIpAddressLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RemoteIpAddressLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            using (LogContext.PushProperty("IPAddress", context.Connection.RemoteIpAddress))
            {
                await _next.Invoke(context);
            }
            
        }
    }
}

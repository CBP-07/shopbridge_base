using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Exceptions;
using Shopbridge_base.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Shopbridge_base.Middleware
{
    public class GlobalResquestHandlerMiddleware
    {
        readonly RequestDelegate _next;
        readonly ILogger<GlobalResquestHandlerMiddleware> logger;
        public GlobalResquestHandlerMiddleware(RequestDelegate next, ILogger<GlobalResquestHandlerMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.ContentType = "application/json";
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                if(ex is ServerResponseException e)
                {
                    await context.Response.Body.WriteAsync((e.GetResponseError).GetBytes());
                    
                }
                else
                await context.Response.Body.WriteAsync(Factory.ErrorResponse().GetBytes());

            }
        }
    }
}

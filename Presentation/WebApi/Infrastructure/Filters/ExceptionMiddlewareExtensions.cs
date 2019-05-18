namespace WebApi.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using NLog;

    public class HttpStatusCodeExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HttpStatusCodeExceptionMiddleware> _logger;
        private Logger _nlogger = LogManager.GetCurrentClassLogger(); // creates a logger using the class name

        public HttpStatusCodeExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this._next = next ?? throw new ArgumentNullException(nameof(next));
            this._logger = loggerFactory?.CreateLogger<HttpStatusCodeExceptionMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this._next(context);
            }
            catch (Exception ex)
            {
                var actionDescriptor = context.Response.Headers
                                            .Where(x => x.Key == "ActionDescriptor").FirstOrDefault().Value;

                this._nlogger = LogManager.GetLogger(actionDescriptor);

                this._nlogger.Error(ex.Message, ex);

                if (context.Response.HasStarted)
                {
                    this._logger.LogWarning("The response has already started, the http status code middleware will not be executed.");
                    throw;
                }

                context.Response.Clear();

                await context.Response.WriteAsync(new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error.",
                    RequestId = context.TraceIdentifier
                }.ToString());

                return;
            }
        }
    }
}
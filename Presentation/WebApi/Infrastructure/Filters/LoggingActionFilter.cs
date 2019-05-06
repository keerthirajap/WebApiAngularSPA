namespace WebApi.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using NLog;

    public class LoggingActionFilter : IAsyncActionFilter
    {
        private Microsoft.Extensions.Logging.ILogger _logger;

        private Logger _nLogger = LogManager.GetCurrentClassLogger(); // creates a logger using the class name

        public LoggingActionFilter(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<LoggingActionFilter>();
        }

        public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
        {
            this._nLogger = LogManager.GetLogger(context.ActionDescriptor.DisplayName);

            try
            {
                this._nLogger.Info(
                "Started method execution '{0}'", context.ActionDescriptor.DisplayName);

                var resultContext = await next();

                if (resultContext.Exception == null)
                {
                    this._nLogger.Info(
                            "Completed method execution '{0}'", context.ActionDescriptor.DisplayName);
                }
                else
                {
                    this._nLogger.Error(
                          "Error occured on method execution - "
                          + resultContext.Exception.Message
                          , resultContext.Exception);

                    //resultContext.Exception = null;

                    throw resultContext.Exception;

                    //throw new HttpRequestException(new HttpResponseMessage(HttpStatusCode.Unauthorized).ToString());

                    //.WriteAsync(new
                    //{
                    //    StatusCode = context.Response.StatusCode,
                    //    Message = "Internal Server Error.",
                    //    RequestId = context.TraceIdentifier
                    //}.ToString());
                }
            }
            catch (Exception ex)
            {
                //this._nLogger.Error(ex.Message, ex);

                throw;
            }
        }
    }
}
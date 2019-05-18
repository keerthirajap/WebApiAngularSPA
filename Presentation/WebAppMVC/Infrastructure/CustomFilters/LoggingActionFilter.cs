namespace WebAppMVC.Infrastructure.CustomFilters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using NLog;

    public class LoggingActionFilter : IAsyncActionFilter
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        private Logger _nogLogger = LogManager.GetCurrentClassLogger(); // creates a logger using the class name

        public LoggingActionFilter(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<LoggingActionFilter>();
        }

        public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
        {
            this._nogLogger = LogManager.GetLogger(context.ActionDescriptor.DisplayName);

            try
            {
                this._nogLogger.Info(
                "Started method execution '{0}'", context.ActionDescriptor.DisplayName);

                var resultContext = await next();

                if (resultContext.Exception == null)
                {
                    this._nogLogger.Info(
                            "Completed method execution '{0}'", context.ActionDescriptor.DisplayName);
                }
                else
                {
                    this._nogLogger.Error(
                          "Error occured on method execution - "
                          + resultContext.Exception.Message
                          , resultContext.Exception);

                    throw resultContext.Exception;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
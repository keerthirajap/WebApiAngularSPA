namespace CrossCutting.Logging
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Castle.DynamicProxy;
    using NLog;

    //Follow anti-pattern only

    public class ServiceClassLogInterceptor : IInterceptor
    {
        private readonly ILogger _logger;

        private Logger _nlogger = LogManager.GetCurrentClassLogger(); // creates a logger using the class name

        public ServiceClassLogInterceptor(ILogger logger)
        {
            this._logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            var codeBase = invocation.MethodInvocationTarget.DeclaringType.AssemblyQualifiedName;
            var invocationTarget = invocation.InvocationTarget.ToString();
            var methodName = invocation.Method.Name;

            try
            {
                var logMethodStartEvent = LogEventInfo.Create(
                                                               LogLevel.Info,
                                                               invocationTarget,
                                                               "Executing Method - " + methodName
                                                               + " | Class - " + invocationTarget);

                logMethodStartEvent.SetCallerInfo(
                                                    invocationTarget,
                                                    methodName + " - ",
                                                    codeBase, 0);
                this._logger.Log(logMethodStartEvent);

                invocation.Proceed();

                var method = invocation.MethodInvocationTarget;

                var isAsync = method.GetCustomAttribute(typeof(AsyncStateMachineAttribute)) != null;

                if (isAsync && typeof(Task).IsAssignableFrom(method.ReturnType))
                {
                    invocation.ReturnValue = InterceptAsync((dynamic)invocation.ReturnValue, this._logger, invocationTarget, methodName, codeBase);
                }

                if (!isAsync)
                {
                    var logMethodEndEvent = LogEventInfo.Create(LogLevel.Info, invocationTarget,
                                                     "Successfuly Executed Method - " + methodName
                                                      + " | Class - " + invocationTarget);

                    logMethodEndEvent.SetCallerInfo(invocationTarget, methodName + " - ",
                                                                             codeBase, 0);
                    this._logger.Log(logMethodEndEvent);
                }
            }
            catch (Exception ex)
            {
                var logMethodErrorEvent = LogEventInfo.Create(LogLevel.Error, invocationTarget,
                                ex, null, "Error Occured on Executing Method - " + methodName
                                 + " | Class - " + invocationTarget +
                                " | Trace - " + ex.InnerException + ex.Message + ex.StackTrace);

                logMethodErrorEvent.SetCallerInfo(invocationTarget, methodName + " - ",
                                                                        codeBase, 0);

                this._logger.Log(logMethodErrorEvent);
                throw;
            }
        }

        private static async Task InterceptAsync(Task task, ILogger _logger, string invocationTarget, string methodName, string codeBase)
        {
            try
            {
                await task.ConfigureAwait(false);

                var logMethodEndEvent = LogEventInfo.Create(LogLevel.Info, invocationTarget,
                                                        "Successfuly Executed Method - " + methodName
                                                      + " | Class - " + invocationTarget);

                logMethodEndEvent.SetCallerInfo(invocationTarget, methodName + " - ",
                                                                         codeBase, 0);
                _logger.Log(logMethodEndEvent);
            }
            catch (Exception ex)
            {
                var logMethodErrorEvent = LogEventInfo.Create(LogLevel.Error, invocationTarget,
                                 ex, null, "Error Occured on Executing Method - " + methodName
                                 + " | Class - " + invocationTarget +
                                " | Trace - " + ex.InnerException + ex.Message + ex.StackTrace);

                logMethodErrorEvent.SetCallerInfo(invocationTarget, methodName + " - ",
                                                                         codeBase, 0);
                _logger.Log(logMethodErrorEvent);
                throw;
            }
        }

        private static async Task<T> InterceptAsync<T>(Task<T> task, ILogger _logger, string invocationTarget, string methodName, string codeBase)
        {
            try
            {
                T result = await task.ConfigureAwait(false);

                var logMethodEndEvent = LogEventInfo.Create(LogLevel.Info, invocationTarget,
                                                      "Successfuly Executed Method - " + methodName
                                                      + " | Class - " + invocationTarget);

                logMethodEndEvent.SetCallerInfo(invocationTarget, methodName + " - ",
                                                                         codeBase, 0);
                _logger.Log(logMethodEndEvent);

                return result;
            }
            catch (Exception ex)
            {
                var logMethodErrorEvent = LogEventInfo.Create(LogLevel.Error, invocationTarget,
                              ex, null, "Error Occured on Executing Method - " + methodName
                                 + " | Class - " + invocationTarget +
                                " | Trace - " + ex.InnerException + ex.Message + ex.StackTrace);

                logMethodErrorEvent.SetCallerInfo(invocationTarget, methodName + " - ",
                                                                         codeBase, 0);
                _logger.Log(logMethodErrorEvent);

                throw;
            }
        }
    }
}
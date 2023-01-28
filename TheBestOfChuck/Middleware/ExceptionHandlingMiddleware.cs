using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestOfChuck.Exceptions;

namespace TheBestOfChuck.Middleware
{
    public class ExceptionHandlingMiddleware : IFunctionsWorkerMiddleware
    {

        private readonly ILogger _logger;
        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) 
        {
            _logger = logger;
        }

        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (InvalidInputDataException e)
            {
                _logger.LogError($"{DateTime.Now}|ERROR|{e.Message}");
            }
            catch (Exception e)
            {
                if(e.InnerException is InvalidInputDataException)
                {
                    _logger.LogError($"{DateTime.Now}|ERROR|{e.Message}");
                }
                else
                {
                    _logger.LogError($"{DateTime.Now}|ERROR|Something went wrong|{e}");
                }
                
            }
        }
    }
}

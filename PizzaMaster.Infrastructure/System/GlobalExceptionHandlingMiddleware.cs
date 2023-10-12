using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PizzaMaster.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Infrastructure.System
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private ILogger<GlobalExceptionHandlingMiddleware> _logger;
        private IErrorService _errorService;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger, IErrorService errorService)
        {
            _logger = logger;
            _errorService = errorService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                _errorService.AddErrorRecord(ex.Message, ex);
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            }
        }
    }
}

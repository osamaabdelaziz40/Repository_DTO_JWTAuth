using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using PRJ.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRJ.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _environment;

        public ExceptionFilter(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public void OnException(ExceptionContext context)
        {
            if (_environment.IsDevelopment())
            {
                context.Result = new ObjectResult(new OutputDTO<dynamic>()
                {
                    Succeeded = false,
                    HttpStatusCode = 500,
                    Message = context.Exception.Message,
                    Data = null
                })
                {
                    StatusCode = 500
                };
            }
            else
            {
                context.Result = new ObjectResult(new OutputDTO<dynamic>()
                {
                    Succeeded = false,
                    HttpStatusCode = 500,
                    Message = context.Exception.Message,
                    Data = null
                })
                {
                    StatusCode = 500
                };
            }

        }
    }
}

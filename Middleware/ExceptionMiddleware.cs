using AutoMapper;
using CVLookup_WebAPI.Utilities;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;
using System.Data;

namespace CVLookup_WebAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            } catch (Exception e)
            {

                ApiResponse response;

                if (e.InnerException == null && e.GetType() == typeof(ExceptionModel))
                {
                    ExceptionModel exception = (ExceptionModel)e;
                    response = new ApiResponse
                    {
                        Success = false,
                        Code = exception.Code,
                        Message = exception.Message,
                    };
                }
                else if (e.InnerException != null && e.InnerException?.GetType() == typeof(ExceptionModel)) 
                { 
                    ExceptionModel exception = (ExceptionModel)e.InnerException;
                    response = new ApiResponse
                    {
                        Success = false,
                        Code = exception.Code,
                        Message = exception.Message,
                    };
                } else
                {
                    response = new ApiResponse
                    {
                        Success = false,
                        Code = 500,
                        Message = e.Message,
                    };
                }
                
                
                if (_env.IsDevelopment())
                {
                    response.Message += System.Environment.NewLine + e.StackTrace;
                }

                await ExceptionResponse.Response(context, 200, response);
            }
        }
    }
}

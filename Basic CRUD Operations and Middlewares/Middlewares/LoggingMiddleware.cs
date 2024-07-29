﻿namespace Basic_CRUD_Operations_and_Middlewares.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            Console.WriteLine($"Response: {context.Response.StatusCode}");
        }
    }
}

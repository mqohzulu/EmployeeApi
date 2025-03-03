using System.Net;
using System.Text.Json;

namespace EmployeeApi
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleWare> _logger;  

        public ExceptionMiddleWare(RequestDelegate next, ILogger<ExceptionMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        } 
        public async Task Invoke (HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred while processing request.");
                await HandleExeptionAsync(context, ex);
            }   
        }
       
        private static Task HandleExeptionAsync(HttpContext context, Exception exeption)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var statusCode = exeption switch
            {
                InvalidOperationException ex => (int)HttpStatusCode.BadRequest,
                KeyNotFoundException ex => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError,
            };
            response.StatusCode = statusCode;
            var result = JsonSerializer.Serialize(new
            {
                message = exeption.Message,
                statusCode
            });
            
            return context.Response.WriteAsync(result);
        }   

    }

}

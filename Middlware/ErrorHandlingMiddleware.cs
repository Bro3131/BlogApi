using System.Net;
using System.Text.Json;

namespace BlogApi.Middlware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // 500 

            //  400
            if (ex is Exception && ex.Message.Contains("не найден"))
                code = HttpStatusCode.NotFound; // 404
            else if (ex.Message.Contains("Неверный"))
                code = HttpStatusCode.BadRequest; // 400

            var result = JsonSerializer.Serialize(new
            {
                error = ex.Message
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}

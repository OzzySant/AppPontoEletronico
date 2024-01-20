using System.Net;

namespace WebApi.Middlwares
{
    public class ErrorMidlware
    {
        private readonly RequestDelegate _next;

        public ErrorMidlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
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

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            var result = exception switch
            {
                InvalidOperationException _ => new { Status = HttpStatusCode.BadRequest, Mensagem = exception.Message },
                _ => new { Status = HttpStatusCode.InternalServerError, Mensagem = "Ocorreu um erro durante a execução da aplicação: " + exception.Message }
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)result.Status;
            await context.Response.WriteAsJsonAsync(new { Erros = result.Mensagem });
        }

    }
}

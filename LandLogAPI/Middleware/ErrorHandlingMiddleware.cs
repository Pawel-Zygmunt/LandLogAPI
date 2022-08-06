using LandLogAPI.Exceptions;
using Newtonsoft.Json;

namespace LandLogAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadHttpRequestException badRequest)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequest.Message);
            }
            catch (NotFoundHttpException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }


        private string GenerateResponse(Exception e)
        {
            return e.Data.Count > 0 ? JsonConvert.SerializeObject(new { errors = e.Data }) : e.Message;
        }
    }
}

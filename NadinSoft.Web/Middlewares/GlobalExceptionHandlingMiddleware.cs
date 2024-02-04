using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace NadinSoft.Web.Middlewares;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    try
    {
      await next(context);
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      var problem = new ProblemDetails
      {
        Status = (int)HttpStatusCode.InternalServerError,
        Type = "server Error",
        Title = "server Error",
        Detail = e.Message,
      };

      var jsonResponse = JsonSerializer.Serialize(problem);
      context.Response.ContentType = "application/json";
      await context.Response.WriteAsync(jsonResponse);
    }
  }
}
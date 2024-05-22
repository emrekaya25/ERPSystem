using ERPSystem.Entity.CustomException;
using ERPSystem.Entity.Result;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ERPSystem.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {

                if (e.GetType() == typeof(FieldValidationException))
                {
                    List<string> errors = new();
                    errors = e.Data["FieldValidationMessage"] as List<string>;

                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ApiResponse<FieldValidationException>.FieldValdationError(errors), new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = null
                    });


                }
                else if (e.GetType() == typeof(TokenValidationException))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ApiResponse<TokenValidationException>.TokenNotFound(), new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = null


                    });
                }
                else if (e.GetType() == typeof(SecurityTokenSignatureKeyNotFoundException))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ApiResponse<TokenValidationException>.TokenValidationError(), new
                        JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = null
                    });

                }
                else if (e.GetType() == typeof(TokenNotFoundException))
                {
                    var message = e.Data["TokenNotFoundMessage"];
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ApiResponse<TokenNotFoundException>.TokenNotFound(), new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = null
                    });
                }
                else if (e.GetType() == typeof(TokenException))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ApiResponse<TokenException>.TokenValidationError(), new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = null
                    });
                }
                else if (e.GetType() == typeof(SqlException) || e.GetType()== typeof(DbUpdateException))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ApiResponse<RelationEntityException>.Error(), new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = null
                    });
                }
                else
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ApiResponse<Exception>.Error(), new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = null
                    });
                }
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}

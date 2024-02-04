using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using NadinSoft.Web.Middlewares;

namespace NadinSoft.Web;

public static class WebProjectServices
{
  public static IServiceCollection AddWebServices(this IServiceCollection services,
    IConfiguration config)
  {
    services.AddTransient<GlobalExceptionHandlingMiddleware>();
    
    services.AddCors(options =>
    {
      options.AddPolicy("CorsPolicy",
        policyBuilder => { policyBuilder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000"); });
    });

    var tokenKey = config["TokenKey"] ?? throw new InvalidOperationException("Invalid Token Key");
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
    {
      opt.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,
        ValidateIssuer = false,
        ValidateAudience = false,
      };
    });

    services.AddControllers(options =>
    {
      var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
      options.Filters.Add(new AuthorizeFilter(policy));
    }).AddJsonOptions(options =>
    {
      options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

    return services;
  }
}
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace NadinSoft.Application;

public static class ApplicationServices
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    services.AddAutoMapper(Assembly.GetExecutingAssembly());
    
    return services;
  }
}
using System.Reflection;
using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NadinSoft.Domain.Entities;

namespace NadinSoft.Infrastructure;

public static class InfrastructureProjectServices
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
    IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    Guard.Against.Null(connectionString, message: "Connection String 'DefaultConnection' Not Found");
    services.AddDbContext<ApplicationDbContext>(options =>
    {
      options.UseSqlServer(connectionString);
    });
    

    return services;
  }
}
using System.Reflection;
using Ardalis.GuardClauses;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NadinSoft.Domain.Abstraction.Identity;
using NadinSoft.Domain.Abstraction.Repositories.Base;
using NadinSoft.Domain.Abstraction.Repositories.User;
using NadinSoft.Domain.Entities;
using NadinSoft.Domain.Models.Identity;
using NadinSoft.Infrastructure.Repositories.Base;
using NadinSoft.Infrastructure.Repositories.User;
using NadinSoft.Infrastructure.Services;
using NadinSoft.Infrastructure.Validators;

namespace NadinSoft.Infrastructure;

public static class InfrastructureProjectServices
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
    IConfiguration configuration)
  {
    services.AddHttpContextAccessor();
    services.AddAutoMapper(Assembly.GetExecutingAssembly());
    services.AddScoped<IIdentityService, IdentityService>();
    services.AddScoped<ITokenService, TokenService>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IUserReadOnlyRepository, UserReadOnlyRepository>();
    services.AddScoped<IUnitOfWork, UnitOfWork>();
    services.AddScoped<IValidator<SignUpDto>, SignUpValidator>();
    services.AddScoped<IValidator<LoginDto>, LoginValidator>();
    
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    Guard.Against.Null(connectionString, message: "Connection String 'DefaultConnection' Not Found");
    services.AddDbContext<ApplicationDbContext>(options =>
    {
      options.UseSqlServer(connectionString);
    });
    
    services.AddIdentityCore<AppUser>()
      .AddEntityFrameworkStores<ApplicationDbContext>()
      .AddSignInManager<SignInManager<AppUser>>();
    
    return services;
  }
}
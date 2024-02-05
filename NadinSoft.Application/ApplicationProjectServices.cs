using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NadinSoft.Application.Products.Commands.Add;
using NadinSoft.Application.Products.Commands.Delete;
using NadinSoft.Application.Products.Queries.Get;

namespace NadinSoft.Application;

public static class ApplicationServices
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    services.AddAutoMapper(Assembly.GetExecutingAssembly());
    services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(AddProductCommand).Assembly));
    services.AddScoped<IValidator<AddProductCommand>, AddProductValidator>();
    services.AddScoped<IValidator<GetProductsQuery>, GetProductsValidator>();
    services.AddScoped<IValidator<DeleteProductCommand>, DeleteProductValidator>();
    
    return services;
  }
}
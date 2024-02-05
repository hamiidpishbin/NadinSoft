using AutoMapper;
using NadinSoft.Application.Products.Commands.Add;
using NadinSoft.Application.Products.Queries.Get;
using NadinSoft.Domain.Entities;

namespace NadinSoft.Application.MappingProfiles;

public class ProductMappingProfile : Profile
{
  public ProductMappingProfile()
  {
    CreateMap<AddProductCommand, Product>();
    CreateMap<AddProductRequest, AddProductCommand>();
    CreateMap<Product, GetProductsResponse>();
  }
}
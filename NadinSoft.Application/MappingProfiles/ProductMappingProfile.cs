using AutoMapper;
using NadinSoft.Application.Products.Commands;
using NadinSoft.Domain.Entities;

namespace NadinSoft.Application.MappingProfiles;

public class ProductMappingProfile : Profile
{
  public ProductMappingProfile()
  {
    CreateMap<AddProductCommand, Product>();
    CreateMap<AddProductRequest, AddProductCommand>();
  }
}
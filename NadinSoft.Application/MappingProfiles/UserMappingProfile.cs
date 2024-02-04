using AutoMapper;
using NadinSoft.Domain.Entities;
using NadinSoft.Domain.Models.Identity;

namespace NadinSoft.Application.MappingProfiles;

public class UserMappingProfile : Profile
{
  public UserMappingProfile()
  {
    CreateMap<SignUpDto, AppUser>();
  }
}
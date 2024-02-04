using NadinSoft.Domain.Entities;

namespace NadinSoft.Domain.Abstraction.Identity;


public interface ITokenService
{
  string CreateToken(AppUser appUser);
}
namespace NadinSoft.Domain.Abstraction.Repositories;

public interface IUserRepository
{
  void Add(Entities.AppUser appUser);
}
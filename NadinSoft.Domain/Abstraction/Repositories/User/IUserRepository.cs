namespace NadinSoft.Domain.Abstraction.Repositories.User;

public interface IUserRepository
{
  void Add(Entities.AppUser appUser);
}
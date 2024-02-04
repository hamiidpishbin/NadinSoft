using NadinSoft.Domain.Abstraction.Repositories;
using NadinSoft.Infrastructure.Repositories.Base;

namespace NadinSoft.Infrastructure.Repositories.User;

internal class UserRepository : Repository<Domain.Entities.AppUser>, IUserRepository
{
  public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
  {
  }

  public new void Add(Domain.Entities.AppUser appUser)
  {
    base.Add(appUser);
  }
}
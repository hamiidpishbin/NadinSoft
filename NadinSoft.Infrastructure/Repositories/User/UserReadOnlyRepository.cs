using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NadinSoft.Domain.Abstraction.Repositories.User;
using NadinSoft.Infrastructure.Repositories.Base;

namespace NadinSoft.Infrastructure.Repositories.User;

internal class UserReadOnlyRepository : ReadOnlyRepository<Domain.Entities.AppUser>, IUserReadOnlyRepository
{
  public UserReadOnlyRepository(ApplicationDbContext dbContext) : base(dbContext)
  {
  }

  public async Task<Domain.Entities.AppUser?> FindByEmailAsync(string email, CancellationToken cancellationToken)
  {
    return await DbContext.Users.AsNoTracking().Where(u => u.Email == email).FirstOrDefaultAsync(cancellationToken);
  }

  public new async Task<bool> AnyAsync(Expression<Func<Domain.Entities.AppUser, bool>> predicate, CancellationToken cancellationToken)
  {
    return await base.AnyAsync(predicate, cancellationToken);
  }
}
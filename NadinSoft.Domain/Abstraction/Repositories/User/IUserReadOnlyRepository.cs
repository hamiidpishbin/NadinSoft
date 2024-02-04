using System.Linq.Expressions;

namespace NadinSoft.Domain.Abstraction.Repositories.User;


public interface IUserReadOnlyRepository
{
  Task<Entities.AppUser?> FindByEmailAsync(string email, CancellationToken cancellationToken = new());
  Task<bool> AnyAsync(Expression<Func<Entities.AppUser, bool>> predicate, CancellationToken cancellationToken = new());
}
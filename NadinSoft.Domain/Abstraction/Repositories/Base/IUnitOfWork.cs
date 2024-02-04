namespace NadinSoft.Domain.Abstraction.Repositories.Base;

public interface IUnitOfWork
{
  Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}
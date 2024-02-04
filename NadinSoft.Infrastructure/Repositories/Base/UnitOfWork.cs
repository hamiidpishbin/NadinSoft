using NadinSoft.Domain.Abstraction.Repositories.Base;

namespace NadinSoft.Infrastructure.Repositories.Base;

internal sealed class UnitOfWork : IUnitOfWork
{
  private readonly ApplicationDbContext _dbContext;

  public UnitOfWork(ApplicationDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  
  public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
  }
}
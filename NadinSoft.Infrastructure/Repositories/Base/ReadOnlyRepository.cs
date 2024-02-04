using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace NadinSoft.Infrastructure.Repositories.Base;

public class ReadOnlyRepository<TEntity> where TEntity : class
{
  protected readonly ApplicationDbContext DbContext;

  public ReadOnlyRepository(ApplicationDbContext dbContext)
  {
    DbContext = dbContext;
  }

  public IEnumerable<TEntity> Get()
  {
    return DbContext.Set<TEntity>().AsNoTracking();
  }

  public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = new())
  {
    return await DbContext.Set<TEntity>().AnyAsync(predicate, cancellationToken);
  }
}
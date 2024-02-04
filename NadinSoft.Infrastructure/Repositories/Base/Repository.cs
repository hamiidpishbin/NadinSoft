namespace NadinSoft.Infrastructure.Repositories.Base;

internal class Repository<TEntity> where TEntity : class
{
  protected readonly ApplicationDbContext DbContext;

  public Repository(ApplicationDbContext dbContext)
  {
    DbContext = dbContext;
  }
  
  public void Add(TEntity entity)
  {
    DbContext.Add(entity);
  }

  public void Update(TEntity entity)
  {
    DbContext.Update(entity);
  }

  public void Remove(TEntity entity)
  {
    DbContext.Remove(entity);
  }
}
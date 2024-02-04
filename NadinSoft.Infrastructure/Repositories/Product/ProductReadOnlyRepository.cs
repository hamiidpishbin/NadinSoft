using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NadinSoft.Domain.Abstraction.Repositories.Product;
using NadinSoft.Infrastructure.Repositories.Base;

namespace NadinSoft.Infrastructure.Repositories.Product;

public class ProductReadOnlyRepository : ReadOnlyRepository<Domain.Entities.Product>, IProductReadOnlyRepository
{
  public ProductReadOnlyRepository(ApplicationDbContext dbContext) : base(dbContext)
  {
  }

  public async Task<IReadOnlyCollection<Domain.Entities.Product>> GetPagedProductsAsync(int currentPage, int pageSize, string userName, CancellationToken cancellationToken)
  {
    var query = DbContext.Products.Include(p => p.User).AsNoTracking();

    return await query.Where(p => p.User.UserName.Contains(userName)).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
  }

  public async Task<Domain.Entities.Product?> FindProductByIdAsync(int productId, bool includeUser, bool asNoTracking)
  {
    var query = DbContext.Products.AsQueryable();
    if (includeUser) query = query.Include(p => p.User);
    if (asNoTracking) query = query.AsNoTracking();
    return await query.FirstOrDefaultAsync(p => p.Id == productId);
  }
  
  public async Task<bool> FindByPropertyValueAsync(Expression<Func<Domain.Entities.Product, bool>> predicate, CancellationToken cancellationToken)
  {
    return await AnyAsync(predicate, cancellationToken);
  }
}
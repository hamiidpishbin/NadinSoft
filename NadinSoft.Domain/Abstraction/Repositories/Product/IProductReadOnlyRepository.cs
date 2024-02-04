using System.Linq.Expressions;

namespace NadinSoft.Domain.Abstraction.Repositories.Product;

public interface IProductReadOnlyRepository
{
  Task<IReadOnlyCollection<Entities.Product>> GetPagedProductsAsync(int currentPage, int pageSize, string userName, CancellationToken cancellationToken = new());
  Task<Entities.Product?> FindProductByIdAsync(int productId, bool includeUser = false, bool asNoTracking = false);
  Task<bool> FindByPropertyValueAsync(Expression<Func<Domain.Entities.Product, bool>> predicate, CancellationToken cancellationToken = new());
}
using NadinSoft.Domain.Abstraction.Repositories.Product;
using NadinSoft.Infrastructure.Repositories.Base;

namespace NadinSoft.Infrastructure.Repositories.Product;

internal class ProductRepository : Repository<Domain.Entities.Product>, IProductRepository
{
  public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
  {
  }

  public void AddProduct(Domain.Entities.Product product)
  {
    Add(product);
  }

  public void UpdateProduct(Domain.Entities.Product product)
  {
    Update(product);
  }

  public void DeleteProduct(Domain.Entities.Product product)
  {
    Remove(product);
  }
}
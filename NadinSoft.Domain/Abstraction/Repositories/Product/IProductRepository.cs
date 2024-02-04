namespace NadinSoft.Domain.Abstraction.Repositories.Product;

public interface IProductRepository
{
  void AddProduct(Entities.Product product);
  void UpdateProduct(Entities.Product product);
  void DeleteProduct(Entities.Product product);
}
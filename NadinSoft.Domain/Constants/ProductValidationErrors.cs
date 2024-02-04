namespace NadinSoft.Domain.Constants;

public static class ProductValidationErrors
{
  public const string PageSizeIsNegative = "Page size must be greater than zero";
  public const string PageIndexIsNegative = "Page index must be greater than zero";
  public const string DuplicateProductDate = "Product date cannot be duplicate.";
  public const string DuplicateManufactureEmail = "Manufacture email cannot be duplicate.";
  public const string AddProductFailed = "Failed to add product.";
  public const string DeleteProductFailed = "Failed to delete product.";
  public const string EditProductFailed = "Failed to edit product.";
  public const string ProductNotFound = "Product not found.";
  public const string UnauthorizedProductDelete = "Cannot delete other users products.";
  public const string UnauthorizedProductEdit = "Cannot edit other users products.";
  public const string InvalidProductId = "Inavlid product Id.";
}
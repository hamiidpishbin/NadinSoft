using FluentValidation;
using NadinSoft.Domain.Constants;

namespace NadinSoft.Application.Products.Queries.Get;

public class GetProductsValidator : AbstractValidator<GetProductsQuery>
{
  public GetProductsValidator()
  {
    RuleFor(model => model.PageSize)
      .GreaterThan(0).WithMessage(ProductValidationErrors.PageSizeIsNegative);
    
    RuleFor(model => model.PageIndex)
      .GreaterThan(0).WithMessage(ProductValidationErrors.PageIndexIsNegative);
  }
}
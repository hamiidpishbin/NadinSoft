using FluentValidation;
using NadinSoft.Domain.Constants;

namespace NadinSoft.Application.Products.Commands.Delete;

public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
  public DeleteProductValidator()
  {
    RuleFor(model => model.Id)
      .NotEqual(0).WithMessage(ProductValidationErrors.InvalidProductId);
  }
}
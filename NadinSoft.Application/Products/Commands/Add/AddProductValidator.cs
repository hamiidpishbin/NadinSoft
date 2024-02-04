using System.Text.RegularExpressions;
using FluentValidation;

namespace NadinSoft.Application.Products.Commands.Add;

public class AddProductValidator : AbstractValidator<AddProductCommand>
{
  public AddProductValidator()
  {
    RuleFor(model => model.Name)
      .NotEmpty()
      .NotNull().WithMessage("Name is required");

    RuleFor(model => model.ManufactureEmail)
      .NotEmpty()
      .NotEmpty().WithMessage("Email is required")
      .EmailAddress().WithMessage("Invalid Email Address");

    RuleFor(model => model.ManufacturePhone)
      .NotEmpty()
      .NotEmpty().WithMessage("Manufacture phone is required")
      .Matches(new Regex(@"^09\d{9}$")).WithMessage("Invalid manufacture phone number");

    RuleFor(model => model.ProductDate)
      .NotEmpty()
      .NotNull().WithMessage("Product date is required");
  }
}
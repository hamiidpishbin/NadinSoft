using FluentValidation;
using NadinSoft.Domain.Constants;
using NadinSoft.Domain.Models.Identity;

namespace NadinSoft.Infrastructure.Validators;

public class LoginValidator : AbstractValidator<LoginDto>
{
  public LoginValidator()
  {
    RuleFor(model => model.Email)
      .EmailAddress().WithMessage(IdentityErrors.InvalidEmail);

    RuleFor(model => model.Password)
      .NotNull()
      .NotEmpty().WithMessage(IdentityErrors.PasswordRequired);
  }
}
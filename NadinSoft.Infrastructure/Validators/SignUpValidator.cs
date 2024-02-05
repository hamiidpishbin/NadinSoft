using FluentValidation;
using NadinSoft.Domain.Constants;
using NadinSoft.Domain.Models.Identity;

namespace NadinSoft.Infrastructure.Validators;

public class SignUpValidator : AbstractValidator<SignUpDto>
{
  public SignUpValidator()
  {
    RuleFor(model => model.UserName)
      .NotNull()
      .NotEmpty().WithMessage(IdentityErrors.UsernameRequired)
      .MinimumLength(3).WithMessage(IdentityErrors.TooShortUsername)
      .MaximumLength(15).WithMessage(IdentityErrors.TooLongUsername);
    
    RuleFor(model => model.DisplayName)
      .NotNull()
      .NotEmpty().WithMessage(IdentityErrors.DisplayNameRequired)
      .MinimumLength(3).WithMessage(IdentityErrors.TooShortDisplayName)
      .MaximumLength(15).WithMessage(IdentityErrors.TooLongDisplayName);
    
    RuleFor(model => model.Email)
      .EmailAddress().WithMessage(IdentityErrors.InvalidEmail);

    RuleFor(model => model.Password)
      .NotEmpty().WithMessage(IdentityErrors.PasswordRequired)
      .MinimumLength(8).WithMessage(IdentityErrors.ShortPassword)
      .MaximumLength(20).WithMessage(IdentityErrors.LongPassword)
      .Matches(@"[A-Z]+").WithMessage(IdentityErrors.NoUpperCaseInPassword)
      .Matches(@"[a-z]+").WithMessage(IdentityErrors.NoLowerCaseInPassword)
      .Matches(@"[0-9]+").WithMessage(IdentityErrors.NoNumberInPassword)
      .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage(IdentityErrors.NoSpecialCharacterInPassword)
      .Matches("^[^£# “”]*$").WithMessage(IdentityErrors.InvalidCharactersInPassword);

    RuleFor(model => model.PasswordConfirm)
      .NotNull()
      .NotEmpty().WithMessage(IdentityErrors.PasswordConfirmationRequired);
  }
}
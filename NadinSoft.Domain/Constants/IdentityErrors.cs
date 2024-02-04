namespace NadinSoft.Domain.Constants;

public static class IdentityErrors
{
  public const string PasswordsNotMatch = "Confirmation password does not password.";
  public const string DuplicateUsername = "Username is already taken.";
  public const string DuplicateEmail = "Email is already taken.";
  public const string CreateUserFailed = "Failed to create user.";
  public const string IncorrectLoginCredentials = "Username and password does not match.";
  public const string LoginFailed = "Login failed.";
  public const string UserNotFound = "User not found.";
  public const string InvalidEmail = "Email address is not valid.";
  public const string PasswordRequired = "Password is required.";
  public const string UsernameRequired = "Username is required.";
  public const string DisplayNameRequired = "Display name is required.";
  public const string TooShortUsername = "Username must have at least 3 characters.";
  public const string TooShortDisplayName = "Display name must have at least 3 characters.";
  public const string TooLongUsername = "Username cannot have more than 15 characters.";
  public const string TooLongDisplayName = "Display name cannot have more than 15 characters.";
  public const string ShortPassword = "Password length must be at least 8.";
  public const string NoUpperCaseInPassword = "Password must contain at least one uppercase letter.";
  public const string NoLowerCaseInPassword = "Password must contain at least one lowercase letter.";
  public const string NoNumberInPassword = "Password must contain at least one number.";
  public const string NoSpecialCharacterInPassword = "Password must contain one or more special characters.";
  public const string InvalidCharactersInPassword = "Password contain the following characters £ # “” or spaces.";
  public const string PasswordConfirmationRequired = "Password confirmation is required.";
}
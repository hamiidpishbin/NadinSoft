namespace NadinSoft.Domain.Models.Identity;

public record SignUpDto
{
  public string UserName { get; set; } = string.Empty;
  public string DisplayName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public string PasswordConfirm { get; set; } = string.Empty;
}
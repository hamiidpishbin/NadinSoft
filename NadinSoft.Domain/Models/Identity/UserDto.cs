namespace NadinSoft.Domain.Models.Identity;

public record UserDto
{
  public string DisplayName { get; set; } = string.Empty;
  public string Token { get; set; } = string.Empty;
}
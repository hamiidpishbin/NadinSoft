using Microsoft.AspNetCore.Identity;

namespace NadinSoft.Domain.Entities;

public class AppUser : IdentityUser<int>
{
  public string DisplayName { get; set; } = string.Empty;
}
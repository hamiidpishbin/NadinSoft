using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NadinSoft.Domain.Entities;

namespace NadinSoft.Infrastructure.EntityConfigs;

public class UserConfigs : IEntityTypeConfiguration<AppUser>
{
  public void Configure(EntityTypeBuilder<AppUser> builder)
  {
    var passwordHasher = new PasswordHasher<AppUser>();

    var user1 = new AppUser()
    {
      Id = 1,
      UserName = "hamidpishbin",
      DisplayName = "Hamid",
      Email = "hamidpishbin@gmail.com",
    };
    user1.PasswordHash = passwordHasher.HashPassword(user1, "Hamid@123");

    var user2 = new AppUser()
    {
      Id = 2,
      UserName = "haniepishbin",
      DisplayName = "Hanie",
      Email = "haniepishbin@gmail.com",
    };
    user2.PasswordHash = passwordHasher.HashPassword(user2, "Hanie@123");
    
  }
}
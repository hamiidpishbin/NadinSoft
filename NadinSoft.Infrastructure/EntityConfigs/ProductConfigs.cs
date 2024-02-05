using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NadinSoft.Domain.Entities;

namespace NadinSoft.Infrastructure.EntityConfigs;

public class ProductConfigs : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {
    builder.Property(p => p.ProductDate).HasColumnType("date");
    
    builder.HasData(new List<Product>
    {
      new()
      {
        Id = 1,
        Name = "Product 1",
        IsAvailable = true,
        ManufactureEmail = "product1email@gmail.com",
        ManufacturePhone = "09110111111",
        ProductDate = DateTime.Today.AddDays(-4),
        UserId = 1
      },
      new()
      {
        Id = 2,
        Name = "Product 2",
        IsAvailable = true,
        ManufactureEmail = "product2email@gmail.com",
        ManufacturePhone = "09120121212",
        ProductDate = DateTime.Today.AddDays(-3),
        UserId = 1
      },
      new()
      {
        Id = 3,
        Name = "Product 3",
        IsAvailable = true,
        ManufactureEmail = "product3email@gmail.com",
        ManufacturePhone = "09130131313",
        ProductDate = DateTime.Today.AddDays(-2),
        UserId = 2
      },
      new()
      {
        Id = 4,
        Name = "Product 4",
        IsAvailable = true,
        ManufactureEmail = "product4email@gmail.com",
        ManufacturePhone = "09140141414",
        ProductDate = DateTime.Today.AddDays(-1),
        UserId = 2
      },
    });
  }
}
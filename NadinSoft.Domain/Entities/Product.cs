namespace NadinSoft.Domain.Entities;

public record Product : BaseEntity
{
  public string Name { get; set; } = string.Empty;
  public bool IsAvailable { get; set; }
  public string ManufactureEmail { get; set; } = string.Empty;
  public string ManufacturePhone { get; set; } = string.Empty;
  public DateTime ProductDate { get; set; }
  public AppUser? User { get; set; }
  public int UserId { get; set; }
}
namespace NadinSoft.Domain.Models.Common;

public record Pagination
{
  public int PageIndex { get; set; }
  public int PageSize { get; set; }
  public int TotalItems { get; set; }
  public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
}
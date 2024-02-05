namespace NadinSoft.Domain.Models.Common;

public record PagedResponse<T>
{
  public IEnumerable<T> Data { get; set; } = Enumerable.Empty<T>();
  public required Pagination Pagination { get; set; }
}
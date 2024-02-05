using MediatR;
using NadinSoft.Domain.Models.Common;

namespace NadinSoft.Application.Products.Queries.Get;

public record GetProductsQuery : IRequest<Result<PagedResponse<GetProductsResponse>>>
{
  public int PageIndex { get; init; }
  public int PageSize { get; init; }
  public string Username { get; init; } = string.Empty;
}
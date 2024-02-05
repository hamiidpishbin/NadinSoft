using MediatR;
using NadinSoft.Domain.Models.Common;

namespace NadinSoft.Application.Products.Commands.Edit;

public record EditProductCommand : IRequest<Result<bool>>
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public bool IsAvailable { get; set; }
  public string ManufactureEmail { get; set; } = string.Empty;
  public string ManufacturePhone { get; set; } = string.Empty;
  public DateTime ProductDate { get; set; }
}
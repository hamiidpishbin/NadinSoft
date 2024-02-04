using MediatR;
using NadinSoft.Domain.Models.Common;

namespace NadinSoft.Application.Products.Commands.Add;

public record AddProductCommand : IRequest<Result<bool>>
{
  public string Name { get; set; } = string.Empty;
  public bool IsAvailable { get; set; }
  public string ManufactureEmail { get; set; } = string.Empty;
  public string ManufacturePhone { get; set; } = string.Empty;
  public DateTime ProductDate { get; set; }
}
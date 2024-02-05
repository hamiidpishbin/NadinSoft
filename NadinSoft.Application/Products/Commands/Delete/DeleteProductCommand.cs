using MediatR;
using NadinSoft.Domain.Models.Common;

namespace NadinSoft.Application.Products.Commands.Delete;

public record DeleteProductCommand : IRequest<Result<bool>> 
{
  public int Id { get; set; }
}
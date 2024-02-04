using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NadinSoft.Application.Products.Commands;
using NadinSoft.Application.Products.Commands.Add;

namespace NadinSoft.Web.Controllers;

public class ProductController : BaseApiController
{
  private readonly IMapper _mapper;

  public ProductController(IMapper mapper)
  {
    _mapper = mapper;
  }

  [HttpPost]
  public async Task<IActionResult> Add(AddProductRequest request, CancellationToken cancellationToken)
  {
    var command = _mapper.Map<AddProductCommand>(request);
    var result = await Mediator!.Send(command, cancellationToken);
    return HandleResult(result);
  }
}
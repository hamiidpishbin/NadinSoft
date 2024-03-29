using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NadinSoft.Application.Products.Commands.Add;
using NadinSoft.Application.Products.Commands.Delete;
using NadinSoft.Application.Products.Commands.Edit;
using NadinSoft.Application.Products.Queries.Get;

namespace NadinSoft.Web.Controllers;

public class ProductController : BaseApiController
{
  private readonly IMapper _mapper;

  public ProductController(IMapper mapper)
  {
    _mapper = mapper;
  }
  
  [HttpGet]
  [AllowAnonymous]
  public async Task<IActionResult> Get(CancellationToken cancellationToken, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string username = "")
  {
    var result = await Mediator!.Send(new GetProductsQuery()
    {
      PageIndex = pageIndex,
      PageSize = pageSize,
      Username = username
    }, cancellationToken);
    
    return Ok(result);
  }

  [HttpPost]
  public async Task<IActionResult> Add(AddProductRequest request, CancellationToken cancellationToken)
  {
    var command = _mapper.Map<AddProductCommand>(request);
    var result = await Mediator!.Send(command, cancellationToken);
    return HandleResult(result);
  }
  
  [HttpPatch]
  public async Task<IActionResult> Update(EditProductRequest request, CancellationToken cancellationToken)
  {
    var command = _mapper.Map<EditProductCommand>(request);
    var result = await Mediator!.Send(command, cancellationToken);
    return HandleResult(result);
  }
  
  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
  {
    var result = await Mediator!.Send(new DeleteProductCommand
    {
      Id = id
    }, cancellationToken);

    return HandleResult(result);
  }
}
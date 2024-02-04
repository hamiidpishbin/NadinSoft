using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NadinSoft.Domain.Models.Common;

namespace NadinSoft.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BaseApiController : ControllerBase
{
  private IMediator? _mediator;

  protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
  
  protected IActionResult HandleResult<T>(Result<T> result)
  {
    return result.Succeeded switch
    {
      true when result.Value != null => Ok(result.Value),
      true when result.Value == null => NotFound(),
      _ => BadRequest(result.Error)
    };
  }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NadinSoft.Domain.Abstraction.Identity;
using NadinSoft.Domain.Models.Identity;

namespace NadinSoft.Web.Controllers;

[AllowAnonymous]
public class AccountController : BaseApiController
{
  private readonly IIdentityService _identityService;

  public AccountController(IIdentityService identityService)
  {
    _identityService = identityService;
  }

  [HttpPost("Login")]
  public async Task<IActionResult> Login(LoginDto loginDto)
  {
    var result = await _identityService.LoginAsync(loginDto);
    return HandleResult(result);
  }

  [HttpPost("Signup")]
  public async Task<IActionResult> Signup(SignUpDto signUpDto)
  {
    var result = await _identityService.CreateUserAsync(signUpDto);
    return HandleResult(result);
  }
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NadinSoft.Domain.Abstraction.Identity;
using NadinSoft.Domain.Entities;

namespace NadinSoft.Infrastructure.Services;

internal class TokenService : ITokenService
{
  private readonly IConfiguration _config;

  public TokenService(IConfiguration config)
  {
    _config = config;
  }

  public string CreateToken(AppUser appUser)
  {
    var claims = new List<Claim>
    {
      new (ClaimTypes.Name, appUser.UserName!),
      new (ClaimTypes.NameIdentifier, appUser.Id.ToString()),
      new (ClaimTypes.Email, appUser.Email!),
    };

    var tokenKey = _config["TokenKey"];
    Guard.Against.Null(tokenKey, message: "Token Key Was Null Or Empty");
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
    var credits = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(claims),
      Expires = DateTime.Now.AddHours(1),
      SigningCredentials = credits,
    };

    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateToken(tokenDescriptor);

    return tokenHandler.WriteToken(token);
  }
}
using NadinSoft.Domain.Entities;
using NadinSoft.Domain.Models.Common;
using NadinSoft.Domain.Models.Identity;

namespace NadinSoft.Domain.Abstraction.Identity;

public interface IIdentityService
{
  Task<Result<bool>> CreateUserAsync(SignUpDto signUpDto);
  Task<Result<UserDto>> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken = new());
  Task<AppUser?> GetCurrentUserAsync(CancellationToken cancellationToken = new());
}
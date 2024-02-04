using System.Security.Claims;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NadinSoft.Domain.Abstraction.Identity;
using NadinSoft.Domain.Abstraction.Repositories.User;
using NadinSoft.Domain.Constants;
using NadinSoft.Domain.Entities;
using NadinSoft.Domain.Models.Common;
using NadinSoft.Domain.Models.Identity;

namespace NadinSoft.Infrastructure.Services;

internal class IdentityService : IIdentityService
{
  private readonly ITokenService _tokenService;
  private readonly IMapper _mapper;
  private readonly IUserReadOnlyRepository _userReadOnlyRepository;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly IValidator<LoginDto> _loginValidator;
  private readonly IValidator<SignUpDto> _signUpValidator;
  private readonly SignInManager<AppUser> _signInManager;
  private readonly UserManager<AppUser> _userManager;

  public IdentityService(
    ITokenService tokenService,
    IMapper mapper,
    IUserReadOnlyRepository userReadOnlyRepository,
    IHttpContextAccessor httpContextAccessor,
    IValidator<LoginDto> loginValidator,
    IValidator<SignUpDto> signUpValidator,
    SignInManager<AppUser> signInManager,
    UserManager<AppUser> userManager)
  {
    _tokenService = tokenService;
    _mapper = mapper;
    _userReadOnlyRepository = userReadOnlyRepository;
    _httpContextAccessor = httpContextAccessor;
    _loginValidator = loginValidator;
    _signUpValidator = signUpValidator;
    _signInManager = signInManager;
    _userManager = userManager;
  }

  #region Public Methods
  public async Task<Result<bool>> CreateUserAsync(SignUpDto signUpDto)
  {
    var validationResult = await _signUpValidator.ValidateAsync(signUpDto);
    if (!validationResult.IsValid) return await Task.FromResult(Result<bool>.Failure(validationResult.Errors.First().ErrorMessage));
    
    if (signUpDto.Password != signUpDto.PasswordConfirm) return Result<bool>.Failure(IdentityErrors.PasswordsNotMatch);

    var userNameIsTaken = await _userReadOnlyRepository.AnyAsync(u => u.UserName == signUpDto.UserName);
    if (userNameIsTaken) return Result<bool>.Failure(IdentityErrors.DuplicateUsername);

    var emailIsTaken = await _userReadOnlyRepository.AnyAsync(u => u.Email == signUpDto.Email);
    if (emailIsTaken) return Result<bool>.Failure(IdentityErrors.DuplicateEmail);
    
    var creationResult = await _userManager.CreateAsync(_mapper.Map<AppUser>(signUpDto), signUpDto.Password);
    
    return creationResult.Succeeded
      ? Result<bool>.Success(true) 
      : Result<bool>.Failure(IdentityErrors.CreateUserFailed);
  }
  
  public async Task<Result<UserDto>> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken)
  {
    var validationResult = await _loginValidator.ValidateAsync(loginDto, cancellationToken);
    if (!validationResult.IsValid) return await Task.FromResult(Result<UserDto>.Failure(validationResult.Errors.First().ErrorMessage));
    
    var user = await _userReadOnlyRepository.FindByEmailAsync(loginDto.Email, cancellationToken);

    if (user == null) return Result<UserDto>.Failure(IdentityErrors.IncorrectLoginCredentials);

    var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

    return signInResult.Succeeded
      ? Result<UserDto>.Success(GetUserDto(user))
      : Result<UserDto>.Failure(IdentityErrors.LoginFailed);
  }

  public async Task<AppUser?> GetCurrentUserAsync(CancellationToken cancellationToken)
  {
    var currentUserEmail = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimValueTypes.Email);
    if (currentUserEmail is null) return await Task.FromResult<AppUser?>(null);
    return await _userReadOnlyRepository.FindByEmailAsync(currentUserEmail, cancellationToken);
  }
  #endregion

  #region Private Methods
  private UserDto GetUserDto(AppUser appUser)
  {
    return new UserDto
    {
      DisplayName = appUser.DisplayName,
      Token = _tokenService.CreateToken(appUser)
    };
  }
  #endregion
}
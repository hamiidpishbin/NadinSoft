using AutoMapper;
using FluentValidation;
using MediatR;
using NadinSoft.Domain.Abstraction.Identity;
using NadinSoft.Domain.Abstraction.Repositories.Base;
using NadinSoft.Domain.Abstraction.Repositories.Product;
using NadinSoft.Domain.Constants;
using NadinSoft.Domain.Entities;
using NadinSoft.Domain.Models.Common;

namespace NadinSoft.Application.Products.Commands;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Result<bool>>
{
  private readonly IIdentityService _identityService;
  private readonly IMapper _mapper;
  private readonly IProductRepository _productRepository;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IProductReadOnlyRepository _productReadOnlyRepository;
  private readonly IValidator<AddProductCommand> _addProductValidator;

  public AddProductCommandHandler(
    IIdentityService identityService,
    IMapper mapper,
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IProductReadOnlyRepository productReadOnlyRepository,
    IValidator<AddProductCommand> addProductValidator)
  {
    _identityService = identityService;
    _mapper = mapper;
    _productRepository = productRepository;
    _unitOfWork = unitOfWork;
    _productReadOnlyRepository = productReadOnlyRepository;
    _addProductValidator = addProductValidator;
  }
  
  public async Task<Result<bool>> Handle(AddProductCommand request, CancellationToken cancellationToken)
  {
    var validationResult = await _addProductValidator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid) return await Task.FromResult(Result<bool>.Failure(validationResult.Errors.First().ErrorMessage));
    
    var currentUser = await _identityService.GetCurrentUserAsync(cancellationToken);
    if (currentUser is null) return Result<bool>.Failure(IdentityErrors.UserNotFound);

    var isProductDateDuplicate = await _productReadOnlyRepository.FindByPropertyValueAsync(p => p.ProductDate == request.ProductDate, cancellationToken);
    if (isProductDateDuplicate) return Result<bool>.Failure(ProductValidationErrors.DuplicateProductDate);

    var isManufactureEmailDuplicate =
      await _productReadOnlyRepository.FindByPropertyValueAsync(p => p.ManufactureEmail == request.ManufactureEmail, cancellationToken);
    if (isManufactureEmailDuplicate) return Result<bool>.Failure(ProductValidationErrors.DuplicateManufactureEmail);

    var product = _mapper.Map<Product>(request);
    product.UserId = currentUser.Id;
    _productRepository.AddProduct(product);
    var saveResult = await _unitOfWork.SaveChangesAsync();
    return saveResult
      ? Result<bool>.Success(true)
      : Result<bool>.Failure(ProductValidationErrors.AddProductFailed);
  }
}
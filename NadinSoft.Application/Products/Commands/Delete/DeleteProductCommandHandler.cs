using FluentValidation;
using MediatR;
using NadinSoft.Domain.Abstraction.Identity;
using NadinSoft.Domain.Abstraction.Repositories.Base;
using NadinSoft.Domain.Abstraction.Repositories.Product;
using NadinSoft.Domain.Constants;
using NadinSoft.Domain.Models.Common;

namespace NadinSoft.Application.Products.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand ,Result<bool>>
{
  private readonly IProductReadOnlyRepository _productReadOnlyRepository;
  private readonly IIdentityService _identityService;
  private readonly IProductRepository _productRepository;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IValidator<DeleteProductCommand> _deleteProductValidator;

  public DeleteProductCommandHandler(
    IProductReadOnlyRepository productReadOnlyRepository,
    IIdentityService identityService,
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IValidator<DeleteProductCommand> deleteProductValidator)
  {
    _productReadOnlyRepository = productReadOnlyRepository;
    _identityService = identityService;
    _productRepository = productRepository;
    _unitOfWork = unitOfWork;
    _deleteProductValidator = deleteProductValidator;
  }
  
  public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
  {
    var validationResult = await _deleteProductValidator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid) return await Task.FromResult(Result<bool>.Failure(validationResult.Errors.First().ErrorMessage));
    
    var productInDb = await _productReadOnlyRepository.FindProductByIdAsync(request.Id, includeUser: true);
    if (productInDb is null) return await Task.FromResult(Result<bool>.Failure(ProductValidationErrors.ProductNotFound));

    var currentUser = await _identityService.GetCurrentUserAsync(cancellationToken);
    if (currentUser is null) return await Task.FromResult(Result<bool>.Failure(IdentityErrors.UserNotFound));
    
    if (productInDb.User.Id != currentUser.Id) return await Task.FromResult(Result<bool>.Failure(ProductValidationErrors.UnauthorizedProductDelete));
    
    _productRepository.DeleteProduct(productInDb);
    var saveResult = await _unitOfWork.SaveChangesAsync();

    return saveResult
      ? Result<bool>.Success(true)
      : Result<bool>.Failure(ProductValidationErrors.DeleteProductFailed);
  }
}
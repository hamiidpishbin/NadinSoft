using AutoMapper;
using MediatR;
using NadinSoft.Domain.Abstraction.Identity;
using NadinSoft.Domain.Abstraction.Repositories.Base;
using NadinSoft.Domain.Abstraction.Repositories.Product;
using NadinSoft.Domain.Constants;
using NadinSoft.Domain.Models.Common;

namespace NadinSoft.Application.Products.Commands.Edit;

public class EditProductCommandHandler : IRequestHandler<EditProductCommand, Result<bool>>
{
  private readonly IProductRepository _productRepository;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IProductReadOnlyRepository _productReadOnlyRepository;
  private readonly IMapper _mapper;
  private readonly IIdentityService _identityService;

  public EditProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IProductReadOnlyRepository productReadOnlyRepository,
    IMapper mapper,
    IIdentityService identityService)
  {
    _productRepository = productRepository;
    _unitOfWork = unitOfWork;
    _productReadOnlyRepository = productReadOnlyRepository;
    _mapper = mapper;
    _identityService = identityService;
  }
  
  public async Task<Result<bool>> Handle(EditProductCommand request, CancellationToken cancellationToken)
  {
    var productInDb = await _productReadOnlyRepository.FindProductByIdAsync(request.Id);
    if (productInDb is null) return Result<bool>.Failure(ProductValidationErrors.ProductNotFound);

    var currentUser = await _identityService.GetCurrentUserAsync(cancellationToken);
    if (currentUser is null) return await Task.FromResult(Result<bool>.Failure(IdentityErrors.UserNotFound));

    if (productInDb.UserId != currentUser.Id) return await Task.FromResult(Result<bool>.Failure(ProductValidationErrors.UnauthorizedProductEdit));
    
    productInDb = _mapper.Map(request, productInDb);

    _productRepository.UpdateProduct(productInDb);
    var saveResult = await _unitOfWork.SaveChangesAsync();

    return saveResult
      ? Result<bool>.Success(true)
      : Result<bool>.Failure(ProductValidationErrors.EditProductFailed);
  }
}
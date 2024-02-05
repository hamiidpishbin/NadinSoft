using AutoMapper;
using FluentValidation;
using MediatR;
using NadinSoft.Domain.Abstraction.Repositories.Product;
using NadinSoft.Domain.Models.Common;

namespace NadinSoft.Application.Products.Queries.Get;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Result<PagedResponse<GetProductsResponse>>>
{
  private readonly IProductReadOnlyRepository _productReadOnlyRepository;
  private readonly IMapper _mapper;
  private readonly IValidator<GetProductsQuery> _getProductsValidator;

  public GetProductsQueryHandler(
    IProductReadOnlyRepository productReadOnlyRepository,
    IMapper mapper,
    IValidator<GetProductsQuery> getProductsValidator)
  {
    _productReadOnlyRepository = productReadOnlyRepository;
    _mapper = mapper;
    _getProductsValidator = getProductsValidator;
  }
  
  public async Task<Result<PagedResponse<GetProductsResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
  {
    var validationResult = await _getProductsValidator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid) return Result<PagedResponse<GetProductsResponse>>.Failure(validationResult.Errors.First().ErrorMessage);

    var items = await _productReadOnlyRepository.GetPagedProductsAsync(request.PageIndex, request.PageSize, request.Username, cancellationToken);
    
    var result = new PagedResponse<GetProductsResponse>
    {
      Data = _mapper.Map<IEnumerable<GetProductsResponse>>(items),
      Pagination = new Pagination
      {
        PageIndex = request.PageIndex,
        PageSize = request.PageSize,
        TotalItems = items.Count
      }
    };
    
    return Result<PagedResponse<GetProductsResponse>>.Success(result);
  }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AnnualStockCountItemQuantity.Queries;

public class GetAnnualStockCountItemQuantityByIdQuery : IQuery<Result<AnnualStockCountItemQuantityDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAnnualStockCountItemQuantityByIdQueryHandler : IQueryHandler<GetAnnualStockCountItemQuantityByIdQuery, Result<AnnualStockCountItemQuantityDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAnnualStockCountItemQuantityByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AnnualStockCountItemQuantityDetailsResponse>> Handle(GetAnnualStockCountItemQuantityByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AnnualStockCountItemQuantityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AnnualStockCountItemQuantityDetailsResponse>.Failure(Errors.AnnualStockCountItemQuantityNotFound);

        var response = entity.Adapt<AnnualStockCountItemQuantityDetailsResponse>();

        return Result<AnnualStockCountItemQuantityDetailsResponse>.Success(response);
    }
}
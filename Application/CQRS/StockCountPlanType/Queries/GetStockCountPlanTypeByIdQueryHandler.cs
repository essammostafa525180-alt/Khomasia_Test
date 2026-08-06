using Application.Abstractions;
using Mapster;

namespace Application.CQRS.StockCountPlanType.Queries;

public class GetStockCountPlanTypeByIdQuery : IQuery<Result<StockCountPlanTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetStockCountPlanTypeByIdQueryHandler : IQueryHandler<GetStockCountPlanTypeByIdQuery, Result<StockCountPlanTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetStockCountPlanTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<StockCountPlanTypeDetailsResponse>> Handle(GetStockCountPlanTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StockCountPlanTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<StockCountPlanTypeDetailsResponse>.Failure(Errors.StockCountPlanTypeNotFound);

        var response = entity.Adapt<StockCountPlanTypeDetailsResponse>();

        return Result<StockCountPlanTypeDetailsResponse>.Success(response);
    }
}
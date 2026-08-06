using Application.Abstractions;
using Mapster;

namespace Application.CQRS.StockCountPlanStatus.Queries;

public class GetStockCountPlanStatusByIdQuery : IQuery<Result<StockCountPlanStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetStockCountPlanStatusByIdQueryHandler : IQueryHandler<GetStockCountPlanStatusByIdQuery, Result<StockCountPlanStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetStockCountPlanStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<StockCountPlanStatusDetailsResponse>> Handle(GetStockCountPlanStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StockCountPlanStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<StockCountPlanStatusDetailsResponse>.Failure(Errors.StockCountPlanStatusNotFound);

        var response = entity.Adapt<StockCountPlanStatusDetailsResponse>();

        return Result<StockCountPlanStatusDetailsResponse>.Success(response);
    }
}
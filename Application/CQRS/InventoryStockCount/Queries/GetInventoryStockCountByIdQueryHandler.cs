using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryStockCount.Queries;

public class GetInventoryStockCountByIdQuery : IQuery<Result<InventoryStockCountDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryStockCountByIdQueryHandler : IQueryHandler<GetInventoryStockCountByIdQuery, Result<InventoryStockCountDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryStockCountByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryStockCountDetailsResponse>> Handle(GetInventoryStockCountByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryStockCountDetailsResponse>.Failure(Errors.InventoryStockCountNotFound);

        var response = entity.Adapt<InventoryStockCountDetailsResponse>();

        return Result<InventoryStockCountDetailsResponse>.Success(response);
    }
}
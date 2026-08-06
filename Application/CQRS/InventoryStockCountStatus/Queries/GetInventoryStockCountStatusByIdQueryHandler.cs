using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryStockCountStatus.Queries;

public class GetInventoryStockCountStatusByIdQuery : IQuery<Result<InventoryStockCountStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryStockCountStatusByIdQueryHandler : IQueryHandler<GetInventoryStockCountStatusByIdQuery, Result<InventoryStockCountStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryStockCountStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryStockCountStatusDetailsResponse>> Handle(GetInventoryStockCountStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryStockCountStatusDetailsResponse>.Failure(Errors.InventoryStockCountStatusNotFound);

        var response = entity.Adapt<InventoryStockCountStatusDetailsResponse>();

        return Result<InventoryStockCountStatusDetailsResponse>.Success(response);
    }
}
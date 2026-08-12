using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryStockCountDetail.Queries;

public class GetInventoryStockCountDetailByIdQuery : IQuery<Result<InventoryStockCountDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryStockCountDetailByIdQueryHandler : IQueryHandler<GetInventoryStockCountDetailByIdQuery, Result<InventoryStockCountDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryStockCountDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryStockCountDetailDetailsResponse>> Handle(GetInventoryStockCountDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryStockCountDetailDetailsResponse>.Failure(Errors.InventoryStockCountDetailNotFound);

        var response = entity.Adapt<InventoryStockCountDetailDetailsResponse>();

        return Result<InventoryStockCountDetailDetailsResponse>.Success(response);
    }
}
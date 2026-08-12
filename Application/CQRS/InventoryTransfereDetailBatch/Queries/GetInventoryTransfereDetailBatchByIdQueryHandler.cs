using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryTransfereDetailBatch.Queries;

public class GetInventoryTransfereDetailBatchByIdQuery : IQuery<Result<InventoryTransfereDetailBatchDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryTransfereDetailBatchByIdQueryHandler : IQueryHandler<GetInventoryTransfereDetailBatchByIdQuery, Result<InventoryTransfereDetailBatchDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryTransfereDetailBatchByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryTransfereDetailBatchDetailsResponse>> Handle(GetInventoryTransfereDetailBatchByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereDetailBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryTransfereDetailBatchDetailsResponse>.Failure(Errors.InventoryTransfereDetailBatchNotFound);

        var response = entity.Adapt<InventoryTransfereDetailBatchDetailsResponse>();

        return Result<InventoryTransfereDetailBatchDetailsResponse>.Success(response);
    }
}
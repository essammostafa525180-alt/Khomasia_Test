using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemStatus.Queries;

public class GetInventoryItemStatusByIdQuery : IQuery<Result<InventoryItemStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemStatusByIdQueryHandler : IQueryHandler<GetInventoryItemStatusByIdQuery, Result<InventoryItemStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemStatusDetailsResponse>> Handle(GetInventoryItemStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemStatusDetailsResponse>.Failure(Errors.InventoryItemStatusNotFound);

        var response = entity.Adapt<InventoryItemStatusDetailsResponse>();

        return Result<InventoryItemStatusDetailsResponse>.Success(response);
    }
}
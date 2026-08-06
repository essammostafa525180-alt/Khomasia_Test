using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemSerialStatus.Queries;

public class GetInventoryItemSerialStatusByIdQuery : IQuery<Result<InventoryItemSerialStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemSerialStatusByIdQueryHandler : IQueryHandler<GetInventoryItemSerialStatusByIdQuery, Result<InventoryItemSerialStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemSerialStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemSerialStatusDetailsResponse>> Handle(GetInventoryItemSerialStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemSerialStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemSerialStatusDetailsResponse>.Failure(Errors.InventoryItemSerialStatusNotFound);

        var response = entity.Adapt<InventoryItemSerialStatusDetailsResponse>();

        return Result<InventoryItemSerialStatusDetailsResponse>.Success(response);
    }
}
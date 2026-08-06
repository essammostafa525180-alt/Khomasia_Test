using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryTransfere.Queries;

public class GetInventoryTransfereByIdQuery : IQuery<Result<InventoryTransfereDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryTransfereByIdQueryHandler : IQueryHandler<GetInventoryTransfereByIdQuery, Result<InventoryTransfereDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryTransfereByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryTransfereDetailsResponse>> Handle(GetInventoryTransfereByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryTransfereDetailsResponse>.Failure(Errors.InventoryTransfereNotFound);

        var response = entity.Adapt<InventoryTransfereDetailsResponse>();

        return Result<InventoryTransfereDetailsResponse>.Success(response);
    }
}
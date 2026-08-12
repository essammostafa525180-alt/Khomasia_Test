using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemLocation.Queries;

public class GetInventoryItemLocationByIdQuery : IQuery<Result<InventoryItemLocationDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemLocationByIdQueryHandler : IQueryHandler<GetInventoryItemLocationByIdQuery, Result<InventoryItemLocationDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemLocationByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemLocationDetailsResponse>> Handle(GetInventoryItemLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemLocationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemLocationDetailsResponse>.Failure(Errors.InventoryItemLocationNotFound);

        var response = entity.Adapt<InventoryItemLocationDetailsResponse>();

        return Result<InventoryItemLocationDetailsResponse>.Success(response);
    }
}
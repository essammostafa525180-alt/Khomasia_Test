using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemLocationDetail.Queries;

public class GetInventoryItemLocationDetailByIdQuery : IQuery<Result<InventoryItemLocationDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemLocationDetailByIdQueryHandler : IQueryHandler<GetInventoryItemLocationDetailByIdQuery, Result<InventoryItemLocationDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemLocationDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemLocationDetailDetailsResponse>> Handle(GetInventoryItemLocationDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemLocationDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemLocationDetailDetailsResponse>.Failure(Errors.InventoryItemLocationDetailNotFound);

        var response = entity.Adapt<InventoryItemLocationDetailDetailsResponse>();

        return Result<InventoryItemLocationDetailDetailsResponse>.Success(response);
    }
}
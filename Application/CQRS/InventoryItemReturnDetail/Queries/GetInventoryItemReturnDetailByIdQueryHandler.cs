using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemReturnDetail.Queries;

public class GetInventoryItemReturnDetailByIdQuery : IQuery<Result<InventoryItemReturnDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemReturnDetailByIdQueryHandler : IQueryHandler<GetInventoryItemReturnDetailByIdQuery, Result<InventoryItemReturnDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemReturnDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemReturnDetailDetailsResponse>> Handle(GetInventoryItemReturnDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemReturnDetailDetailsResponse>.Failure(Errors.InventoryItemReturnDetailNotFound);

        var response = entity.Adapt<InventoryItemReturnDetailDetailsResponse>();

        return Result<InventoryItemReturnDetailDetailsResponse>.Success(response);
    }
}
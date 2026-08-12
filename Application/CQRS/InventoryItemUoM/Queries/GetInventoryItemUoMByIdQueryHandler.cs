using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemUoM.Queries;

public class GetInventoryItemUoMByIdQuery : IQuery<Result<InventoryItemUoMDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemUoMByIdQueryHandler : IQueryHandler<GetInventoryItemUoMByIdQuery, Result<InventoryItemUoMDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemUoMByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemUoMDetailsResponse>> Handle(GetInventoryItemUoMByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemUoMRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemUoMDetailsResponse>.Failure(Errors.InventoryItemUoMNotFound);

        var response = entity.Adapt<InventoryItemUoMDetailsResponse>();

        return Result<InventoryItemUoMDetailsResponse>.Success(response);
    }
}
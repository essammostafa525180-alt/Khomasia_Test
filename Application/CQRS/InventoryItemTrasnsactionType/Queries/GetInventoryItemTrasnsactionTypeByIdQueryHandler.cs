using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemTrasnsactionType.Queries;

public class GetInventoryItemTrasnsactionTypeByIdQuery : IQuery<Result<InventoryItemTrasnsactionTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemTrasnsactionTypeByIdQueryHandler : IQueryHandler<GetInventoryItemTrasnsactionTypeByIdQuery, Result<InventoryItemTrasnsactionTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemTrasnsactionTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemTrasnsactionTypeDetailsResponse>> Handle(GetInventoryItemTrasnsactionTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemTrasnsactionTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemTrasnsactionTypeDetailsResponse>.Failure(Errors.InventoryItemTrasnsactionTypeNotFound);

        var response = entity.Adapt<InventoryItemTrasnsactionTypeDetailsResponse>();

        return Result<InventoryItemTrasnsactionTypeDetailsResponse>.Success(response);
    }
}
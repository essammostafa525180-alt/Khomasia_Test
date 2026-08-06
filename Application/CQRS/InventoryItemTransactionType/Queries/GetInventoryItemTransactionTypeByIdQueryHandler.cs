using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemTransactionType.Queries;

public class GetInventoryItemTransactionTypeByIdQuery : IQuery<Result<InventoryItemTransactionTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemTransactionTypeByIdQueryHandler : IQueryHandler<GetInventoryItemTransactionTypeByIdQuery, Result<InventoryItemTransactionTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemTransactionTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemTransactionTypeDetailsResponse>> Handle(GetInventoryItemTransactionTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemTransactionTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemTransactionTypeDetailsResponse>.Failure(Errors.InventoryItemTransactionTypeNotFound);

        var response = entity.Adapt<InventoryItemTransactionTypeDetailsResponse>();

        return Result<InventoryItemTransactionTypeDetailsResponse>.Success(response);
    }
}
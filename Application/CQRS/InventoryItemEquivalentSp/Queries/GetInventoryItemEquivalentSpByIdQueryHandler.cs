using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemEquivalentSp.Queries;

public class GetInventoryItemEquivalentSpByIdQuery : IQuery<Result<InventoryItemEquivalentSpDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemEquivalentSpByIdQueryHandler : IQueryHandler<GetInventoryItemEquivalentSpByIdQuery, Result<InventoryItemEquivalentSpDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemEquivalentSpByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemEquivalentSpDetailsResponse>> Handle(GetInventoryItemEquivalentSpByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemEquivalentSpRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemEquivalentSpDetailsResponse>.Failure(Errors.InventoryItemEquivalentSpNotFound);

        var response = entity.Adapt<InventoryItemEquivalentSpDetailsResponse>();

        return Result<InventoryItemEquivalentSpDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryTransfereDetail.Queries;

public class GetInventoryTransfereDetailByIdQuery : IQuery<Result<InventoryTransfereDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryTransfereDetailByIdQueryHandler : IQueryHandler<GetInventoryTransfereDetailByIdQuery, Result<InventoryTransfereDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryTransfereDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryTransfereDetailDetailsResponse>> Handle(GetInventoryTransfereDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryTransfereDetailDetailsResponse>.Failure(Errors.InventoryTransfereDetailNotFound);

        var response = entity.Adapt<InventoryTransfereDetailDetailsResponse>();

        return Result<InventoryTransfereDetailDetailsResponse>.Success(response);
    }
}
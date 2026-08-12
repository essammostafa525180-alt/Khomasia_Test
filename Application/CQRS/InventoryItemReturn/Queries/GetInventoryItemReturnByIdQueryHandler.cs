using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemReturn.Queries;

public class GetInventoryItemReturnByIdQuery : IQuery<Result<InventoryItemReturnDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemReturnByIdQueryHandler : IQueryHandler<GetInventoryItemReturnByIdQuery, Result<InventoryItemReturnDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemReturnByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemReturnDetailsResponse>> Handle(GetInventoryItemReturnByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemReturnDetailsResponse>.Failure(Errors.InventoryItemReturnNotFound);

        var response = entity.Adapt<InventoryItemReturnDetailsResponse>();

        return Result<InventoryItemReturnDetailsResponse>.Success(response);
    }
}
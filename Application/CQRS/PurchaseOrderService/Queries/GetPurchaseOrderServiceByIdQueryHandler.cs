using Application.Abstractions;
using Mapster;

namespace Application.CQRS.PurchaseOrderService.Queries;

public class GetPurchaseOrderServiceByIdQuery : IQuery<Result<PurchaseOrderServiceDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetPurchaseOrderServiceByIdQueryHandler : IQueryHandler<GetPurchaseOrderServiceByIdQuery, Result<PurchaseOrderServiceDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPurchaseOrderServiceByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PurchaseOrderServiceDetailsResponse>> Handle(GetPurchaseOrderServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PurchaseOrderServiceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<PurchaseOrderServiceDetailsResponse>.Failure(Errors.PurchaseOrderServiceNotFound);

        var response = entity.Adapt<PurchaseOrderServiceDetailsResponse>();

        return Result<PurchaseOrderServiceDetailsResponse>.Success(response);
    }
}
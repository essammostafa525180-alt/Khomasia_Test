using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderQualityDetailBatch.Queries;

public class GetVendorOrderQualityDetailBatchByIdQuery : IQuery<Result<VendorOrderQualityDetailBatchDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderQualityDetailBatchByIdQueryHandler : IQueryHandler<GetVendorOrderQualityDetailBatchByIdQuery, Result<VendorOrderQualityDetailBatchDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderQualityDetailBatchByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderQualityDetailBatchDetailsResponse>> Handle(GetVendorOrderQualityDetailBatchByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderQualityDetailBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderQualityDetailBatchDetailsResponse>.Failure(Errors.VendorOrderQualityDetailBatchNotFound);

        var response = entity.Adapt<VendorOrderQualityDetailBatchDetailsResponse>();

        return Result<VendorOrderQualityDetailBatchDetailsResponse>.Success(response);
    }
}
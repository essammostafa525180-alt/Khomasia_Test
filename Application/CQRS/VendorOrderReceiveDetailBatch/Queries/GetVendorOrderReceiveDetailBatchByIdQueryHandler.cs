using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderReceiveDetailBatch.Queries;

public class GetVendorOrderReceiveDetailBatchByIdQuery : IQuery<Result<VendorOrderReceiveDetailBatchDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderReceiveDetailBatchByIdQueryHandler : IQueryHandler<GetVendorOrderReceiveDetailBatchByIdQuery, Result<VendorOrderReceiveDetailBatchDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderReceiveDetailBatchByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderReceiveDetailBatchDetailsResponse>> Handle(GetVendorOrderReceiveDetailBatchByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveDetailBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderReceiveDetailBatchDetailsResponse>.Failure(Errors.VendorOrderReceiveDetailBatchNotFound);

        var response = entity.Adapt<VendorOrderReceiveDetailBatchDetailsResponse>();

        return Result<VendorOrderReceiveDetailBatchDetailsResponse>.Success(response);
    }
}
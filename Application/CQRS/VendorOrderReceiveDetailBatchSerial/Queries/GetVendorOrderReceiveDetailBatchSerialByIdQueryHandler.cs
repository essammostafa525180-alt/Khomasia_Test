using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderReceiveDetailBatchSerial.Queries;

public class GetVendorOrderReceiveDetailBatchSerialByIdQuery : IQuery<Result<VendorOrderReceiveDetailBatchSerialDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderReceiveDetailBatchSerialByIdQueryHandler : IQueryHandler<GetVendorOrderReceiveDetailBatchSerialByIdQuery, Result<VendorOrderReceiveDetailBatchSerialDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderReceiveDetailBatchSerialByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderReceiveDetailBatchSerialDetailsResponse>> Handle(GetVendorOrderReceiveDetailBatchSerialByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveDetailBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderReceiveDetailBatchSerialDetailsResponse>.Failure(Errors.VendorOrderReceiveDetailBatchSerialNotFound);

        var response = entity.Adapt<VendorOrderReceiveDetailBatchSerialDetailsResponse>();

        return Result<VendorOrderReceiveDetailBatchSerialDetailsResponse>.Success(response);
    }
}
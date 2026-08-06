using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorReturnDetailBatchSerial.Queries;

public class GetVendorReturnDetailBatchSerialByIdQuery : IQuery<Result<VendorReturnDetailBatchSerialDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorReturnDetailBatchSerialByIdQueryHandler : IQueryHandler<GetVendorReturnDetailBatchSerialByIdQuery, Result<VendorReturnDetailBatchSerialDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorReturnDetailBatchSerialByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorReturnDetailBatchSerialDetailsResponse>> Handle(GetVendorReturnDetailBatchSerialByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnDetailBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorReturnDetailBatchSerialDetailsResponse>.Failure(Errors.VendorReturnDetailBatchSerialNotFound);

        var response = entity.Adapt<VendorReturnDetailBatchSerialDetailsResponse>();

        return Result<VendorReturnDetailBatchSerialDetailsResponse>.Success(response);
    }
}
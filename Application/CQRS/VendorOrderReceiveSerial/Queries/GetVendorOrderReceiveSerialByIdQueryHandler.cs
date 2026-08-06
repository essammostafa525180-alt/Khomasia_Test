using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderReceiveSerial.Queries;

public class GetVendorOrderReceiveSerialByIdQuery : IQuery<Result<VendorOrderReceiveSerialDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderReceiveSerialByIdQueryHandler : IQueryHandler<GetVendorOrderReceiveSerialByIdQuery, Result<VendorOrderReceiveSerialDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderReceiveSerialByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderReceiveSerialDetailsResponse>> Handle(GetVendorOrderReceiveSerialByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderReceiveSerialDetailsResponse>.Failure(Errors.VendorOrderReceiveSerialNotFound);

        var response = entity.Adapt<VendorOrderReceiveSerialDetailsResponse>();

        return Result<VendorOrderReceiveSerialDetailsResponse>.Success(response);
    }
}
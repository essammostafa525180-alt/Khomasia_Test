using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorReturnSerial.Queries;

public class GetVendorReturnSerialByIdQuery : IQuery<Result<VendorReturnSerialDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorReturnSerialByIdQueryHandler : IQueryHandler<GetVendorReturnSerialByIdQuery, Result<VendorReturnSerialDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorReturnSerialByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorReturnSerialDetailsResponse>> Handle(GetVendorReturnSerialByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorReturnSerialDetailsResponse>.Failure(Errors.VendorReturnSerialNotFound);

        var response = entity.Adapt<VendorReturnSerialDetailsResponse>();

        return Result<VendorReturnSerialDetailsResponse>.Success(response);
    }
}
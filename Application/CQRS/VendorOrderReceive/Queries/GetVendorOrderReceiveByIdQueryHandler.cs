using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderReceive.Queries;

public class GetVendorOrderReceiveByIdQuery : IQuery<Result<VendorOrderReceiveDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderReceiveByIdQueryHandler : IQueryHandler<GetVendorOrderReceiveByIdQuery, Result<VendorOrderReceiveDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderReceiveByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderReceiveDetailsResponse>> Handle(GetVendorOrderReceiveByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderReceiveDetailsResponse>.Failure(Errors.VendorOrderReceiveNotFound);

        var response = entity.Adapt<VendorOrderReceiveDetailsResponse>();

        return Result<VendorOrderReceiveDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderReceiveDetail.Queries;

public class GetVendorOrderReceiveDetailByIdQuery : IQuery<Result<VendorOrderReceiveDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderReceiveDetailByIdQueryHandler : IQueryHandler<GetVendorOrderReceiveDetailByIdQuery, Result<VendorOrderReceiveDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderReceiveDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderReceiveDetailDetailsResponse>> Handle(GetVendorOrderReceiveDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderReceiveDetailDetailsResponse>.Failure(Errors.VendorOrderReceiveDetailNotFound);

        var response = entity.Adapt<VendorOrderReceiveDetailDetailsResponse>();

        return Result<VendorOrderReceiveDetailDetailsResponse>.Success(response);
    }
}
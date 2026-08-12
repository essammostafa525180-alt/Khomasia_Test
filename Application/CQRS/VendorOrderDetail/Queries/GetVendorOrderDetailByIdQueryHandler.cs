using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderDetail.Queries;

public class GetVendorOrderDetailByIdQuery : IQuery<Result<VendorOrderDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderDetailByIdQueryHandler : IQueryHandler<GetVendorOrderDetailByIdQuery, Result<VendorOrderDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderDetailDetailsResponse>> Handle(GetVendorOrderDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderDetailDetailsResponse>.Failure(Errors.VendorOrderDetailNotFound);

        var response = entity.Adapt<VendorOrderDetailDetailsResponse>();

        return Result<VendorOrderDetailDetailsResponse>.Success(response);
    }
}
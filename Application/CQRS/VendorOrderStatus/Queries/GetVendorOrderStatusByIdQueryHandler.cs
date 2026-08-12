using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderStatus.Queries;

public class GetVendorOrderStatusByIdQuery : IQuery<Result<VendorOrderStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderStatusByIdQueryHandler : IQueryHandler<GetVendorOrderStatusByIdQuery, Result<VendorOrderStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderStatusDetailsResponse>> Handle(GetVendorOrderStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderStatusDetailsResponse>.Failure(Errors.VendorOrderStatusNotFound);

        var response = entity.Adapt<VendorOrderStatusDetailsResponse>();

        return Result<VendorOrderStatusDetailsResponse>.Success(response);
    }
}
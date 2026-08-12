using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrder.Queries;

public class GetVendorOrderByIdQuery : IQuery<Result<VendorOrderDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderByIdQueryHandler : IQueryHandler<GetVendorOrderByIdQuery, Result<VendorOrderDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderDetailsResponse>> Handle(GetVendorOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderDetailsResponse>.Failure(Errors.VendorOrderNotFound);

        var response = entity.Adapt<VendorOrderDetailsResponse>();

        return Result<VendorOrderDetailsResponse>.Success(response);
    }
}
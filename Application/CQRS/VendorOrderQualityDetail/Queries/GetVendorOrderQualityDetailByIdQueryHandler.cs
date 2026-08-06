using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderQualityDetail.Queries;

public class GetVendorOrderQualityDetailByIdQuery : IQuery<Result<VendorOrderQualityDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderQualityDetailByIdQueryHandler : IQueryHandler<GetVendorOrderQualityDetailByIdQuery, Result<VendorOrderQualityDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderQualityDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderQualityDetailDetailsResponse>> Handle(GetVendorOrderQualityDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderQualityDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderQualityDetailDetailsResponse>.Failure(Errors.VendorOrderQualityDetailNotFound);

        var response = entity.Adapt<VendorOrderQualityDetailDetailsResponse>();

        return Result<VendorOrderQualityDetailDetailsResponse>.Success(response);
    }
}
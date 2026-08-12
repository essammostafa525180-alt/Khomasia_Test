using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderQuality.Queries;

public class GetVendorOrderQualityByIdQuery : IQuery<Result<VendorOrderQualityDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderQualityByIdQueryHandler : IQueryHandler<GetVendorOrderQualityByIdQuery, Result<VendorOrderQualityDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderQualityByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderQualityDetailsResponse>> Handle(GetVendorOrderQualityByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderQualityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderQualityDetailsResponse>.Failure(Errors.VendorOrderQualityNotFound);

        var response = entity.Adapt<VendorOrderQualityDetailsResponse>();

        return Result<VendorOrderQualityDetailsResponse>.Success(response);
    }
}
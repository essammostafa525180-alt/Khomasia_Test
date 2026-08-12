using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Vendor.Queries;

public class GetVendorByIdQuery : IQuery<Result<VendorDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorByIdQueryHandler : IQueryHandler<GetVendorByIdQuery, Result<VendorDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorDetailsResponse>> Handle(GetVendorByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorDetailsResponse>.Failure(Errors.VendorNotFound);

        var response = entity.Adapt<VendorDetailsResponse>();

        return Result<VendorDetailsResponse>.Success(response);
    }
}
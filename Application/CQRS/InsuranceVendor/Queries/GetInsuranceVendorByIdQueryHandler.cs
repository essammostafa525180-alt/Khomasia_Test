using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InsuranceVendor.Queries;

public class GetInsuranceVendorByIdQuery : IQuery<Result<InsuranceVendorDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInsuranceVendorByIdQueryHandler : IQueryHandler<GetInsuranceVendorByIdQuery, Result<InsuranceVendorDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInsuranceVendorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InsuranceVendorDetailsResponse>> Handle(GetInsuranceVendorByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InsuranceVendorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InsuranceVendorDetailsResponse>.Failure(Errors.InsuranceVendorNotFound);

        var response = entity.Adapt<InsuranceVendorDetailsResponse>();

        return Result<InsuranceVendorDetailsResponse>.Success(response);
    }
}
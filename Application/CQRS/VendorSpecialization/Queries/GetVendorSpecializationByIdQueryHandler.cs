using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorSpecialization.Queries;

public class GetVendorSpecializationByIdQuery : IQuery<Result<VendorSpecializationDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorSpecializationByIdQueryHandler : IQueryHandler<GetVendorSpecializationByIdQuery, Result<VendorSpecializationDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorSpecializationByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorSpecializationDetailsResponse>> Handle(GetVendorSpecializationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorSpecializationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorSpecializationDetailsResponse>.Failure(Errors.VendorSpecializationNotFound);

        var response = entity.Adapt<VendorSpecializationDetailsResponse>();

        return Result<VendorSpecializationDetailsResponse>.Success(response);
    }
}
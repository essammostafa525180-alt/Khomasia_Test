using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssignVendorSpecialization.Queries;

public class GetAssignVendorSpecializationByIdQuery : IQuery<Result<AssignVendorSpecializationDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssignVendorSpecializationByIdQueryHandler : IQueryHandler<GetAssignVendorSpecializationByIdQuery, Result<AssignVendorSpecializationDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssignVendorSpecializationByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssignVendorSpecializationDetailsResponse>> Handle(GetAssignVendorSpecializationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssignVendorSpecializationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssignVendorSpecializationDetailsResponse>.Failure(Errors.AssignVendorSpecializationNotFound);

        var response = entity.Adapt<AssignVendorSpecializationDetailsResponse>();

        return Result<AssignVendorSpecializationDetailsResponse>.Success(response);
    }
}
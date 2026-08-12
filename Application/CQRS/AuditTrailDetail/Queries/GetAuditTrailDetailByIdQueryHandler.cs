using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AuditTrailDetail.Queries;

public class GetAuditTrailDetailByIdQuery : IQuery<Result<AuditTrailDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAuditTrailDetailByIdQueryHandler : IQueryHandler<GetAuditTrailDetailByIdQuery, Result<AuditTrailDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAuditTrailDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AuditTrailDetailDetailsResponse>> Handle(GetAuditTrailDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AuditTrailDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AuditTrailDetailDetailsResponse>.Failure(Errors.AuditTrailDetailNotFound);

        var response = entity.Adapt<AuditTrailDetailDetailsResponse>();

        return Result<AuditTrailDetailDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AuditTrail.Queries;

public class GetAuditTrailByIdQuery : IQuery<Result<AuditTrailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAuditTrailByIdQueryHandler : IQueryHandler<GetAuditTrailByIdQuery, Result<AuditTrailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAuditTrailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AuditTrailDetailsResponse>> Handle(GetAuditTrailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AuditTrailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AuditTrailDetailsResponse>.Failure(Errors.AuditTrailNotFound);

        var response = entity.Adapt<AuditTrailDetailsResponse>();

        return Result<AuditTrailDetailsResponse>.Success(response);
    }
}
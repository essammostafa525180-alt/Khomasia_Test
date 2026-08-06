using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssignSiteSection.Queries;

public class GetAssignSiteSectionByIdQuery : IQuery<Result<AssignSiteSectionDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssignSiteSectionByIdQueryHandler : IQueryHandler<GetAssignSiteSectionByIdQuery, Result<AssignSiteSectionDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssignSiteSectionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssignSiteSectionDetailsResponse>> Handle(GetAssignSiteSectionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssignSiteSectionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssignSiteSectionDetailsResponse>.Failure(Errors.AssignSiteSectionNotFound);

        var response = entity.Adapt<AssignSiteSectionDetailsResponse>();

        return Result<AssignSiteSectionDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Project.Queries;

public class GetProjectByIdQuery : IQuery<Result<ProjectDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetProjectByIdQueryHandler : IQueryHandler<GetProjectByIdQuery, Result<ProjectDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProjectByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ProjectDetailsResponse>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ProjectRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ProjectDetailsResponse>.Failure(Errors.ProjectNotFound);

        var response = entity.Adapt<ProjectDetailsResponse>();

        return Result<ProjectDetailsResponse>.Success(response);
    }
}
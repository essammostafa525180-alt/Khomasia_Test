using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Project.Queries;

public class GetAllProjectQuery
: IQuery<Result<PagingSortingFiltering<ProjectDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllProjectQueryHandler :
    IQueryHandler<GetAllProjectQuery,
        Result<PagingSortingFiltering<ProjectDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProjectQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ProjectDetailsResponse>>> Handle(
        GetAllProjectQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ProjectRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ProjectDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ProjectDetailsResponse>>.Success(result);
    }
}
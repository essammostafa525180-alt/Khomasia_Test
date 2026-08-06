using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.EmployeeJob.Queries;

public class GetAllEmployeeJobQuery
: IQuery<Result<PagingSortingFiltering<EmployeeJobDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllEmployeeJobQueryHandler :
    IQueryHandler<GetAllEmployeeJobQuery,
        Result<PagingSortingFiltering<EmployeeJobDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEmployeeJobQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<EmployeeJobDetailsResponse>>> Handle(
        GetAllEmployeeJobQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.EmployeeJobRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<EmployeeJobDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<EmployeeJobDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Employee.Queries;

public class GetAllEmployeeQuery
: IQuery<Result<PagingSortingFiltering<EmployeeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllEmployeeQueryHandler :
    IQueryHandler<GetAllEmployeeQuery,
        Result<PagingSortingFiltering<EmployeeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEmployeeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<EmployeeDetailsResponse>>> Handle(
        GetAllEmployeeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.EmployeeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<EmployeeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<EmployeeDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Pdaassignment.Queries;

public class GetAllPdaassignmentQuery
: IQuery<Result<PagingSortingFiltering<PdaassignmentDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPdaassignmentQueryHandler :
    IQueryHandler<GetAllPdaassignmentQuery,
        Result<PagingSortingFiltering<PdaassignmentDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPdaassignmentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<PdaassignmentDetailsResponse>>> Handle(
        GetAllPdaassignmentQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PdaassignmentRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<PdaassignmentDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PdaassignmentDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecModel.Queries;

public class GetAllSecModelQuery
: IQuery<Result<PagingSortingFiltering<SecModelDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecModelQueryHandler :
    IQueryHandler<GetAllSecModelQuery,
        Result<PagingSortingFiltering<SecModelDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecModelQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecModelDetailsResponse>>> Handle(
        GetAllSecModelQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecModelRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecModelDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecModelDetailsResponse>>.Success(result);
    }
}
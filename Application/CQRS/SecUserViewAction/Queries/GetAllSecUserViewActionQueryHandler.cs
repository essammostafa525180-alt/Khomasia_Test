using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecUserViewAction.Queries;

public class GetAllSecUserViewActionQuery
: IQuery<Result<PagingSortingFiltering<SecUserViewActionDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecUserViewActionQueryHandler :
    IQueryHandler<GetAllSecUserViewActionQuery,
        Result<PagingSortingFiltering<SecUserViewActionDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecUserViewActionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecUserViewActionDetailsResponse>>> Handle(
        GetAllSecUserViewActionQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecUserViewActionRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecUserViewActionDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecUserViewActionDetailsResponse>>.Success(result);
    }
}
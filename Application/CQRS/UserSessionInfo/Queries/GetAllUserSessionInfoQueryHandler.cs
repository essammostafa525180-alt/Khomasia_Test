using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.UserSessionInfo.Queries;

public class GetAllUserSessionInfoQuery
: IQuery<Result<PagingSortingFiltering<UserSessionInfoDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllUserSessionInfoQueryHandler :
    IQueryHandler<GetAllUserSessionInfoQuery,
        Result<PagingSortingFiltering<UserSessionInfoDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUserSessionInfoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<UserSessionInfoDetailsResponse>>> Handle(
        GetAllUserSessionInfoQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.UserSessionInfoRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<UserSessionInfoDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<UserSessionInfoDetailsResponse>>.Success(result);
    }
}
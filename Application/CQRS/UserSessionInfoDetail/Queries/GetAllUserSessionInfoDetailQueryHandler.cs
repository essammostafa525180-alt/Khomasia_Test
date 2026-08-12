using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.UserSessionInfoDetail.Queries;

public class GetAllUserSessionInfoDetailQuery
: IQuery<Result<PagingSortingFiltering<UserSessionInfoDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllUserSessionInfoDetailQueryHandler :
    IQueryHandler<GetAllUserSessionInfoDetailQuery,
        Result<PagingSortingFiltering<UserSessionInfoDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUserSessionInfoDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<UserSessionInfoDetailDetailsResponse>>> Handle(
        GetAllUserSessionInfoDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.UserSessionInfoDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<UserSessionInfoDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<UserSessionInfoDetailDetailsResponse>>.Success(result);
    }
}
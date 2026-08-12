using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AdUser.Queries;

public class GetAllAdUserQuery
: IQuery<Result<PagingSortingFiltering<AdUserDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAdUserQueryHandler :
    IQueryHandler<GetAllAdUserQuery,
        Result<PagingSortingFiltering<AdUserDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAdUserQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AdUserDetailsResponse>>> Handle(
        GetAllAdUserQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AdUserRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AdUserDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AdUserDetailsResponse>>.Success(result);
    }
}
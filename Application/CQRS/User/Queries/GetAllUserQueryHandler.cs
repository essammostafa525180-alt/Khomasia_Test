using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.User.Queries;

public class GetAllUserQuery
: IQuery<Result<PagingSortingFiltering<UserDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllUserQueryHandler :
    IQueryHandler<GetAllUserQuery,
        Result<PagingSortingFiltering<UserDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUserQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<UserDetailsResponse>>> Handle(
        GetAllUserQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.UserRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<UserDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<UserDetailsResponse>>.Success(result);
    }
}
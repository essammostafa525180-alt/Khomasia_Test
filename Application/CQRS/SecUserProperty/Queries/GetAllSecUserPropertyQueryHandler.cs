using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecUserProperty.Queries;

public class GetAllSecUserPropertyQuery
: IQuery<Result<PagingSortingFiltering<SecUserPropertyDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecUserPropertyQueryHandler :
    IQueryHandler<GetAllSecUserPropertyQuery,
        Result<PagingSortingFiltering<SecUserPropertyDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecUserPropertyQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecUserPropertyDetailsResponse>>> Handle(
        GetAllSecUserPropertyQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecUserPropertyRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecUserPropertyDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecUserPropertyDetailsResponse>>.Success(result);
    }
}
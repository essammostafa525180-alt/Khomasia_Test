using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecProperty.Queries;

public class GetAllSecPropertyQuery
: IQuery<Result<PagingSortingFiltering<SecPropertyDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecPropertyQueryHandler :
    IQueryHandler<GetAllSecPropertyQuery,
        Result<PagingSortingFiltering<SecPropertyDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecPropertyQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecPropertyDetailsResponse>>> Handle(
        GetAllSecPropertyQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecPropertyRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecPropertyDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecPropertyDetailsResponse>>.Success(result);
    }
}
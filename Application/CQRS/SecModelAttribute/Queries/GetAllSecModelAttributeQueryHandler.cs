using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecModelAttribute.Queries;

public class GetAllSecModelAttributeQuery
: IQuery<Result<PagingSortingFiltering<SecModelAttributeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecModelAttributeQueryHandler :
    IQueryHandler<GetAllSecModelAttributeQuery,
        Result<PagingSortingFiltering<SecModelAttributeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecModelAttributeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecModelAttributeDetailsResponse>>> Handle(
        GetAllSecModelAttributeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecModelAttributeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecModelAttributeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecModelAttributeDetailsResponse>>.Success(result);
    }
}
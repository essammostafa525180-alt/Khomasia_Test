using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Ownership.Queries;

public class GetAllOwnershipQuery
: IQuery<Result<PagingSortingFiltering<OwnershipDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllOwnershipQueryHandler :
    IQueryHandler<GetAllOwnershipQuery,
        Result<PagingSortingFiltering<OwnershipDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllOwnershipQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<OwnershipDetailsResponse>>> Handle(
        GetAllOwnershipQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.OwnershipRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<OwnershipDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<OwnershipDetailsResponse>>.Success(result);
    }
}
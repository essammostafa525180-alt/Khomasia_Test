using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ContactType.Queries;

public class GetAllContactTypeQuery
: IQuery<Result<PagingSortingFiltering<ContactTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllContactTypeQueryHandler :
    IQueryHandler<GetAllContactTypeQuery,
        Result<PagingSortingFiltering<ContactTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllContactTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ContactTypeDetailsResponse>>> Handle(
        GetAllContactTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ContactTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ContactTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ContactTypeDetailsResponse>>.Success(result);
    }
}
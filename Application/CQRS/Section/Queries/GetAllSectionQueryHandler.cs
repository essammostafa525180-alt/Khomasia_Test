using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Section.Queries;

public class GetAllSectionQuery
: IQuery<Result<PagingSortingFiltering<SectionDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSectionQueryHandler :
    IQueryHandler<GetAllSectionQuery,
        Result<PagingSortingFiltering<SectionDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSectionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SectionDetailsResponse>>> Handle(
        GetAllSectionQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SectionRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SectionDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SectionDetailsResponse>>.Success(result);
    }
}
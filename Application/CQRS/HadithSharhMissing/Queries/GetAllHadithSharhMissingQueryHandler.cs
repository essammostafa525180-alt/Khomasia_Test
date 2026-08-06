using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.HadithSharhMissing.Queries;

public class GetAllHadithSharhMissingQuery
: IQuery<Result<PagingSortingFiltering<HadithSharhMissingDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllHadithSharhMissingQueryHandler :
    IQueryHandler<GetAllHadithSharhMissingQuery,
        Result<PagingSortingFiltering<HadithSharhMissingDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllHadithSharhMissingQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<HadithSharhMissingDetailsResponse>>> Handle(
        GetAllHadithSharhMissingQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.HadithSharhMissingRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<HadithSharhMissingDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<HadithSharhMissingDetailsResponse>>.Success(result);
    }
}
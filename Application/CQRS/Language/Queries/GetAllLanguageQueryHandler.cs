using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Language.Queries;

public class GetAllLanguageQuery
: IQuery<Result<PagingSortingFiltering<LanguageDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllLanguageQueryHandler :
    IQueryHandler<GetAllLanguageQuery,
        Result<PagingSortingFiltering<LanguageDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllLanguageQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<LanguageDetailsResponse>>> Handle(
        GetAllLanguageQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.LanguageRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<LanguageDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<LanguageDetailsResponse>>.Success(result);
    }
}
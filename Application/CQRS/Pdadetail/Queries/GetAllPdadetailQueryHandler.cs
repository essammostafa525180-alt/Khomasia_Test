using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Pdadetail.Queries;

public class GetAllPdadetailQuery
: IQuery<Result<PagingSortingFiltering<PdadetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPdadetailQueryHandler :
    IQueryHandler<GetAllPdadetailQuery,
        Result<PagingSortingFiltering<PdadetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPdadetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<PdadetailDetailsResponse>>> Handle(
        GetAllPdadetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PdadetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<PdadetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PdadetailDetailsResponse>>.Success(result);
    }
}
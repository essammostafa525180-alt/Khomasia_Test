using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.PoserviceOutsource.Queries;

public class GetAllPoserviceOutsourceQuery
: IQuery<Result<PagingSortingFiltering<PoserviceOutsourceDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPoserviceOutsourceQueryHandler :
    IQueryHandler<GetAllPoserviceOutsourceQuery,
        Result<PagingSortingFiltering<PoserviceOutsourceDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPoserviceOutsourceQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<PoserviceOutsourceDetailsResponse>>> Handle(
        GetAllPoserviceOutsourceQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PoserviceOutsourceRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<PoserviceOutsourceDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PoserviceOutsourceDetailsResponse>>.Success(result);
    }
}
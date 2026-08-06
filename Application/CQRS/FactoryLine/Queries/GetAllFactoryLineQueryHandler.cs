using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.FactoryLine.Queries;

public class GetAllFactoryLineQuery
: IQuery<Result<PagingSortingFiltering<FactoryLineDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllFactoryLineQueryHandler :
    IQueryHandler<GetAllFactoryLineQuery,
        Result<PagingSortingFiltering<FactoryLineDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllFactoryLineQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<FactoryLineDetailsResponse>>> Handle(
        GetAllFactoryLineQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.FactoryLineRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<FactoryLineDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<FactoryLineDetailsResponse>>.Success(result);
    }
}
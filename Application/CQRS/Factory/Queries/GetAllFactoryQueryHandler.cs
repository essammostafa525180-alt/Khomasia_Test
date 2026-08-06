using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Factory.Queries;

public class GetAllFactoryQuery
: IQuery<Result<PagingSortingFiltering<FactoryDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllFactoryQueryHandler :
    IQueryHandler<GetAllFactoryQuery,
        Result<PagingSortingFiltering<FactoryDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllFactoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<FactoryDetailsResponse>>> Handle(
        GetAllFactoryQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.FactoryRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<FactoryDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<FactoryDetailsResponse>>.Success(result);
    }
}
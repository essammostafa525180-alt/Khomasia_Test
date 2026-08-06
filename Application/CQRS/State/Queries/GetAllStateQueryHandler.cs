using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.State.Queries;

public class GetAllStateQuery
: IQuery<Result<PagingSortingFiltering<StateDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllStateQueryHandler :
    IQueryHandler<GetAllStateQuery,
        Result<PagingSortingFiltering<StateDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllStateQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<StateDetailsResponse>>> Handle(
        GetAllStateQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.StateRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<StateDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<StateDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecUserModelAtrribute.Queries;

public class GetAllSecUserModelAtrributeQuery
: IQuery<Result<PagingSortingFiltering<SecUserModelAtrributeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecUserModelAtrributeQueryHandler :
    IQueryHandler<GetAllSecUserModelAtrributeQuery,
        Result<PagingSortingFiltering<SecUserModelAtrributeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecUserModelAtrributeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecUserModelAtrributeDetailsResponse>>> Handle(
        GetAllSecUserModelAtrributeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecUserModelAtrributeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecUserModelAtrributeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecUserModelAtrributeDetailsResponse>>.Success(result);
    }
}
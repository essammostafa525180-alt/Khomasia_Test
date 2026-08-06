using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.TransfereType.Queries;

public class GetAllTransfereTypeQuery
: IQuery<Result<PagingSortingFiltering<TransfereTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllTransfereTypeQueryHandler :
    IQueryHandler<GetAllTransfereTypeQuery,
        Result<PagingSortingFiltering<TransfereTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTransfereTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<TransfereTypeDetailsResponse>>> Handle(
        GetAllTransfereTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.TransfereTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<TransfereTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<TransfereTypeDetailsResponse>>.Success(result);
    }
}
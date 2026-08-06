using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.TransferStatus.Queries;

public class GetAllTransferStatusQuery
: IQuery<Result<PagingSortingFiltering<TransferStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllTransferStatusQueryHandler :
    IQueryHandler<GetAllTransferStatusQuery,
        Result<PagingSortingFiltering<TransferStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTransferStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<TransferStatusDetailsResponse>>> Handle(
        GetAllTransferStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.TransferStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<TransferStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<TransferStatusDetailsResponse>>.Success(result);
    }
}
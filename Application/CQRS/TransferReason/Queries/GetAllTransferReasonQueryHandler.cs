using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.TransferReason.Queries;

public class GetAllTransferReasonQuery
: IQuery<Result<PagingSortingFiltering<TransferReasonDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllTransferReasonQueryHandler :
    IQueryHandler<GetAllTransferReasonQuery,
        Result<PagingSortingFiltering<TransferReasonDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTransferReasonQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<TransferReasonDetailsResponse>>> Handle(
        GetAllTransferReasonQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.TransferReasonRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<TransferReasonDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<TransferReasonDetailsResponse>>.Success(result);
    }
}
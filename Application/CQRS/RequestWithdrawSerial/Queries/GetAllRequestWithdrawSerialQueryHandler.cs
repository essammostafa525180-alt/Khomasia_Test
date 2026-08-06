using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.RequestWithdrawSerial.Queries;

public class GetAllRequestWithdrawSerialQuery
: IQuery<Result<PagingSortingFiltering<RequestWithdrawSerialDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllRequestWithdrawSerialQueryHandler :
    IQueryHandler<GetAllRequestWithdrawSerialQuery,
        Result<PagingSortingFiltering<RequestWithdrawSerialDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRequestWithdrawSerialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<RequestWithdrawSerialDetailsResponse>>> Handle(
        GetAllRequestWithdrawSerialQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.RequestWithdrawSerialRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<RequestWithdrawSerialDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<RequestWithdrawSerialDetailsResponse>>.Success(result);
    }
}
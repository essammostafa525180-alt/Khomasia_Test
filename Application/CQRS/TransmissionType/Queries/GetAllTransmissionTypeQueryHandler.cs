using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.TransmissionType.Queries;

public class GetAllTransmissionTypeQuery
: IQuery<Result<PagingSortingFiltering<TransmissionTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllTransmissionTypeQueryHandler :
    IQueryHandler<GetAllTransmissionTypeQuery,
        Result<PagingSortingFiltering<TransmissionTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTransmissionTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<TransmissionTypeDetailsResponse>>> Handle(
        GetAllTransmissionTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.TransmissionTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<TransmissionTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<TransmissionTypeDetailsResponse>>.Success(result);
    }
}
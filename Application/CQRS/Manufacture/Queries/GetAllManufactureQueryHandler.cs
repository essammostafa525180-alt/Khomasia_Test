using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Manufacture.Queries;

public class GetAllManufactureQuery
: IQuery<Result<PagingSortingFiltering<ManufactureDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllManufactureQueryHandler :
    IQueryHandler<GetAllManufactureQuery,
        Result<PagingSortingFiltering<ManufactureDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllManufactureQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ManufactureDetailsResponse>>> Handle(
        GetAllManufactureQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ManufactureRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ManufactureDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ManufactureDetailsResponse>>.Success(result);
    }
}
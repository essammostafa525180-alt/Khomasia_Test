using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Pdamodel.Queries;

public class GetAllPdamodelQuery
: IQuery<Result<PagingSortingFiltering<PdamodelDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPdamodelQueryHandler :
    IQueryHandler<GetAllPdamodelQuery,
        Result<PagingSortingFiltering<PdamodelDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPdamodelQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<PdamodelDetailsResponse>>> Handle(
        GetAllPdamodelQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PdamodelRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<PdamodelDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PdamodelDetailsResponse>>.Success(result);
    }
}
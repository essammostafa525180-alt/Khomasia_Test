using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ChemicalGroup.Queries;

public class GetAllChemicalGroupQuery
: IQuery<Result<PagingSortingFiltering<ChemicalGroupDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllChemicalGroupQueryHandler :
    IQueryHandler<GetAllChemicalGroupQuery,
        Result<PagingSortingFiltering<ChemicalGroupDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllChemicalGroupQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ChemicalGroupDetailsResponse>>> Handle(
        GetAllChemicalGroupQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ChemicalGroupRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ChemicalGroupDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ChemicalGroupDetailsResponse>>.Success(result);
    }
}
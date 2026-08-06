using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssignAssetTypeToAssetGroup.Queries;

public class GetAllAssignAssetTypeToAssetGroupQuery
: IQuery<Result<PagingSortingFiltering<AssignAssetTypeToAssetGroupDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssignAssetTypeToAssetGroupQueryHandler :
    IQueryHandler<GetAllAssignAssetTypeToAssetGroupQuery,
        Result<PagingSortingFiltering<AssignAssetTypeToAssetGroupDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssignAssetTypeToAssetGroupQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssignAssetTypeToAssetGroupDetailsResponse>>> Handle(
        GetAllAssignAssetTypeToAssetGroupQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssignAssetTypeToAssetGroupRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssignAssetTypeToAssetGroupDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssignAssetTypeToAssetGroupDetailsResponse>>.Success(result);
    }
}
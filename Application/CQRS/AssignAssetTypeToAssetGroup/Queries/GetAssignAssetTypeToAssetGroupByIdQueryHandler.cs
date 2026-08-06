using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssignAssetTypeToAssetGroup.Queries;

public class GetAssignAssetTypeToAssetGroupByIdQuery : IQuery<Result<AssignAssetTypeToAssetGroupDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssignAssetTypeToAssetGroupByIdQueryHandler : IQueryHandler<GetAssignAssetTypeToAssetGroupByIdQuery, Result<AssignAssetTypeToAssetGroupDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssignAssetTypeToAssetGroupByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssignAssetTypeToAssetGroupDetailsResponse>> Handle(GetAssignAssetTypeToAssetGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssignAssetTypeToAssetGroupRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssignAssetTypeToAssetGroupDetailsResponse>.Failure(Errors.AssignAssetTypeToAssetGroupNotFound);

        var response = entity.Adapt<AssignAssetTypeToAssetGroupDetailsResponse>();

        return Result<AssignAssetTypeToAssetGroupDetailsResponse>.Success(response);
    }
}
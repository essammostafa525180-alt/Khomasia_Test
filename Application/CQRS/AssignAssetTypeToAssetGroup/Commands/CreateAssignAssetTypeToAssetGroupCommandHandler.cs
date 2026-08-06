using Application.Abstractions;

namespace Application.CQRS.AssignAssetTypeToAssetGroup.Commands;

public class CreateAssignAssetTypeToAssetGroupCommand : ICommand<Result<int>>
{
        public int? AssetTypeFk { get; set; }
        public int? AssetGroupFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssignAssetTypeToAssetGroupCommandHandler : ICommandHandler<CreateAssignAssetTypeToAssetGroupCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssignAssetTypeToAssetGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssignAssetTypeToAssetGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.AssignAssetTypeToAssetGroup.Create(request.AssetTypeFk, request.AssetGroupFk, request.IsActive);

        await _unitOfWork.AssignAssetTypeToAssetGroupRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssignAssetTypeToAssetGroupNotInserted);
    }
}
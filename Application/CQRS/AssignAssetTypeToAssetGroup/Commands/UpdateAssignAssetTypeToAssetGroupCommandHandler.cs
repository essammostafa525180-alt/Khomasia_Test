using Application.Abstractions;

namespace Application.CQRS.AssignAssetTypeToAssetGroup.Commands;

public class UpdateAssignAssetTypeToAssetGroupCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? AssetTypeFk { get; set; }
        public int? AssetGroupFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssignAssetTypeToAssetGroupCommandHandler : ICommandHandler<UpdateAssignAssetTypeToAssetGroupCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssignAssetTypeToAssetGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssignAssetTypeToAssetGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssignAssetTypeToAssetGroupRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssignAssetTypeToAssetGroupNotFound);

        entity.Update(request.AssetTypeFk, request.AssetGroupFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssignAssetTypeToAssetGroupNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.AssignAssetTypeToAssetGroup.Commands;

public class DeleteAssignAssetTypeToAssetGroupCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssignAssetTypeToAssetGroupCommandHandler : ICommandHandler<DeleteAssignAssetTypeToAssetGroupCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssignAssetTypeToAssetGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssignAssetTypeToAssetGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssignAssetTypeToAssetGroupRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssignAssetTypeToAssetGroupNotFound);

        _unitOfWork.AssignAssetTypeToAssetGroupRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssignAssetTypeToAssetGroupNotDeleted);
    }
}
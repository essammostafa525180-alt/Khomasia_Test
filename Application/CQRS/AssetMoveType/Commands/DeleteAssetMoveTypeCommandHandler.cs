using Application.Abstractions;

namespace Application.CQRS.AssetMoveType.Commands;

public class DeleteAssetMoveTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetMoveTypeCommandHandler : ICommandHandler<DeleteAssetMoveTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetMoveTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetMoveTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetMoveTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetMoveTypeNotFound);

        _unitOfWork.AssetMoveTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetMoveTypeNotDeleted);
    }
}
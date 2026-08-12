using Application.Abstractions;

namespace Application.CQRS.AssetCountDetail.Commands;

public class DeleteAssetCountDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetCountDetailCommandHandler : ICommandHandler<DeleteAssetCountDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetCountDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetCountDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountDetailNotFound);

        _unitOfWork.AssetCountDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountDetailNotDeleted);
    }
}
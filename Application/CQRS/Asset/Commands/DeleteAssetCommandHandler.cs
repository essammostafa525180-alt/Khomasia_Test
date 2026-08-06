using Application.Abstractions;

namespace Application.CQRS.Asset.Commands;

public class DeleteAssetCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetCommandHandler : ICommandHandler<DeleteAssetCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetNotFound);

        _unitOfWork.AssetRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetNotDeleted);
    }
}
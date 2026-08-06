using Application.Abstractions;

namespace Application.CQRS.AssetItemScrap.Commands;

public class DeleteAssetItemScrapCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetItemScrapCommandHandler : ICommandHandler<DeleteAssetItemScrapCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetItemScrapCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetItemScrapCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetItemScrapRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetItemScrapNotFound);

        _unitOfWork.AssetItemScrapRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetItemScrapNotDeleted);
    }
}
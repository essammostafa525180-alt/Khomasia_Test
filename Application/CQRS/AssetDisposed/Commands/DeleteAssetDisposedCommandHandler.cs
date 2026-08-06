using Application.Abstractions;

namespace Application.CQRS.AssetDisposed.Commands;

public class DeleteAssetDisposedCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetDisposedCommandHandler : ICommandHandler<DeleteAssetDisposedCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetDisposedCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetDisposedCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetDisposedRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetDisposedNotFound);

        _unitOfWork.AssetDisposedRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetDisposedNotDeleted);
    }
}
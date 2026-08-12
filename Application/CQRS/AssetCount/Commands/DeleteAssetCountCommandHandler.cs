using Application.Abstractions;

namespace Application.CQRS.AssetCount.Commands;

public class DeleteAssetCountCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetCountCommandHandler : ICommandHandler<DeleteAssetCountCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetCountCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetCountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountNotFound);

        _unitOfWork.AssetCountRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountNotDeleted);
    }
}
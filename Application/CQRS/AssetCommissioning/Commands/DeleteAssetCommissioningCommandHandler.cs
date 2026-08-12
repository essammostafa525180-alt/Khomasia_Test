using Application.Abstractions;

namespace Application.CQRS.AssetCommissioning.Commands;

public class DeleteAssetCommissioningCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetCommissioningCommandHandler : ICommandHandler<DeleteAssetCommissioningCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetCommissioningCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetCommissioningCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCommissioningRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCommissioningNotFound);

        _unitOfWork.AssetCommissioningRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCommissioningNotDeleted);
    }
}
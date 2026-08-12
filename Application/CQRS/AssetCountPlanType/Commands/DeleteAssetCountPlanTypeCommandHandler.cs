using Application.Abstractions;

namespace Application.CQRS.AssetCountPlanType.Commands;

public class DeleteAssetCountPlanTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetCountPlanTypeCommandHandler : ICommandHandler<DeleteAssetCountPlanTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetCountPlanTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetCountPlanTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountPlanTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountPlanTypeNotFound);

        _unitOfWork.AssetCountPlanTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountPlanTypeNotDeleted);
    }
}
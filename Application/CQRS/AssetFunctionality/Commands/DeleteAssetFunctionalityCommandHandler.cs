using Application.Abstractions;

namespace Application.CQRS.AssetFunctionality.Commands;

public class DeleteAssetFunctionalityCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetFunctionalityCommandHandler : ICommandHandler<DeleteAssetFunctionalityCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetFunctionalityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetFunctionalityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetFunctionalityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetFunctionalityNotFound);

        _unitOfWork.AssetFunctionalityRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetFunctionalityNotDeleted);
    }
}
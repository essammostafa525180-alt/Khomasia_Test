using Application.Abstractions;

namespace Application.CQRS.AssetStatus.Commands;

public class DeleteAssetStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetStatusCommandHandler : ICommandHandler<DeleteAssetStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetStatusNotFound);

        _unitOfWork.AssetStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetStatusNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.PoserviceAsset.Commands;

public class DeletePoserviceAssetCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeletePoserviceAssetCommandHandler : ICommandHandler<DeletePoserviceAssetCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePoserviceAssetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePoserviceAssetCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceAssetRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PoserviceAssetNotFound);

        _unitOfWork.PoserviceAssetRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PoserviceAssetNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.AssetWarrantyStatus.Commands;

public class DeleteAssetWarrantyStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetWarrantyStatusCommandHandler : ICommandHandler<DeleteAssetWarrantyStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetWarrantyStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetWarrantyStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetWarrantyStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetWarrantyStatusNotFound);

        _unitOfWork.AssetWarrantyStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetWarrantyStatusNotDeleted);
    }
}
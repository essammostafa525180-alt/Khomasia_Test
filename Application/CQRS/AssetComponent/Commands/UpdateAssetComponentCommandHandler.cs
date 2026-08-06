using Application.Abstractions;

namespace Application.CQRS.AssetComponent.Commands;

public class UpdateAssetComponentCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? AssetFk { get; set; }
        public int? ComponentFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetComponentCommandHandler : ICommandHandler<UpdateAssetComponentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetComponentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetComponentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetComponentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetComponentNotFound);

        entity.Update(request.AssetFk, request.ComponentFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetComponentNotUpdated);
    }
}
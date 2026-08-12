using Application.Abstractions;

namespace Application.CQRS.AssetCountDetail.Commands;

public class UpdateAssetCountDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? AssetCountFk { get; set; }
        public int? AssetFk { get; set; }
        public int? AssetCountStatusFk { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetCountDetailCommandHandler : ICommandHandler<UpdateAssetCountDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetCountDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetCountDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountDetailNotFound);

        entity.Update(request.AssetCountFk, request.AssetFk, request.AssetCountStatusFk, request.Notes, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountDetailNotUpdated);
    }
}
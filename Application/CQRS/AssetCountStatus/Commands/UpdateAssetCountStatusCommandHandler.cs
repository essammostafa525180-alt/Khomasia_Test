using Application.Abstractions;

namespace Application.CQRS.AssetCountStatus.Commands;

public class UpdateAssetCountStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetCountStatusCommandHandler : ICommandHandler<UpdateAssetCountStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetCountStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetCountStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountStatusNotUpdated);
    }
}
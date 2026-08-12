using Application.Abstractions;

namespace Application.CQRS.AssetDisposed.Commands;

public class UpdateAssetDisposedCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? OrganizationName { get; set; }
        public decimal? Cost { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetDisposedCommandHandler : ICommandHandler<UpdateAssetDisposedCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetDisposedCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetDisposedCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetDisposedRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetDisposedNotFound);

        entity.Update(request.OrganizationName, request.Cost, request.Notes, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetDisposedNotUpdated);
    }
}
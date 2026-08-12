using Application.Abstractions;

namespace Application.CQRS.AssetMaintenanceStatus.Commands;

public class UpdateAssetMaintenanceStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetMaintenanceStatusCommandHandler : ICommandHandler<UpdateAssetMaintenanceStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetMaintenanceStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetMaintenanceStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetMaintenanceStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetMaintenanceStatusNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetMaintenanceStatusNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.PoserviceAsset.Commands;

public class UpdatePoserviceAssetCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int PoserviceFk { get; set; }
        public int ContractServiceId { get; set; }
        public int ContractAssetId { get; set; }
        public int AssetId { get; set; }
        public string? AssetCode { get; set; }
        public string? AssetDescription { get; set; }
        public string? AssetDescriptionAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdatePoserviceAssetCommandHandler : ICommandHandler<UpdatePoserviceAssetCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePoserviceAssetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePoserviceAssetCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceAssetRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PoserviceAssetNotFound);

        entity.Update(request.PoserviceFk, request.ContractServiceId, request.ContractAssetId, request.AssetId, request.AssetCode, request.AssetDescription, request.AssetDescriptionAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PoserviceAssetNotUpdated);
    }
}
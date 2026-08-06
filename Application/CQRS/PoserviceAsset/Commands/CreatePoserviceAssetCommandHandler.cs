using Application.Abstractions;

namespace Application.CQRS.PoserviceAsset.Commands;

public class CreatePoserviceAssetCommand : ICommand<Result<int>>
{
        public int PoserviceFk { get; set; }
        public int ContractServiceId { get; set; }
        public int ContractAssetId { get; set; }
        public int AssetId { get; set; }
        public string? AssetCode { get; set; }
        public string? AssetDescription { get; set; }
        public string? AssetDescriptionAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreatePoserviceAssetCommandHandler : ICommandHandler<CreatePoserviceAssetCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePoserviceAssetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreatePoserviceAssetCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.PoserviceAsset.Create(request.PoserviceFk, request.ContractServiceId, request.ContractAssetId, request.AssetId, request.AssetCode, request.AssetDescription, request.AssetDescriptionAr, request.IsActive);

        await _unitOfWork.PoserviceAssetRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.PoserviceAssetNotInserted);
    }
}
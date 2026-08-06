using Application.Abstractions;

namespace Application.CQRS.AssetCommissioning.Commands;

public class UpdateAssetCommissioningCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? AssetFk { get; set; }
        public int? CommissionConditionFk { get; set; }
        public int? AssetFunctionalityFk { get; set; }
        public int? AssetComplineFk { get; set; }
        public int? SubSectionFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetCommissioningCommandHandler : ICommandHandler<UpdateAssetCommissioningCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetCommissioningCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetCommissioningCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCommissioningRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCommissioningNotFound);

        entity.Update(request.AssetFk, request.CommissionConditionFk, request.AssetFunctionalityFk, request.AssetComplineFk, request.SubSectionFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCommissioningNotUpdated);
    }
}
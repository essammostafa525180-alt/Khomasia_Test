using Application.Abstractions;

namespace Application.CQRS.AssetItemScrap.Commands;

public class UpdateAssetItemScrapCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? AssetItemFk { get; set; }
        public string? Code { get; set; }
        public int? AssetItemMoveFk { get; set; }
        public int? AssetItemMaintenanceFk { get; set; }
        public int? AssetScrapStatusFk { get; set; }
        public int? ApprovalStatusFk { get; set; }
        public decimal? SoldAmount { get; set; }
        public DateTime? ActionDate { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetItemScrapCommandHandler : ICommandHandler<UpdateAssetItemScrapCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetItemScrapCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetItemScrapCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetItemScrapRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetItemScrapNotFound);

        entity.Update(request.AssetItemFk, request.Code, request.AssetItemMoveFk, request.AssetItemMaintenanceFk, request.AssetScrapStatusFk, request.ApprovalStatusFk, request.SoldAmount, request.ActionDate, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetItemScrapNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.AssetItemScrap.Commands;

public class CreateAssetItemScrapCommand : ICommand<Result<int>>
{
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
internal class CreateAssetItemScrapCommandHandler : ICommandHandler<CreateAssetItemScrapCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetItemScrapCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetItemScrapCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.AssetItemScrap.Create(request.AssetItemFk, request.Code, request.AssetItemMoveFk, request.AssetItemMaintenanceFk, request.AssetScrapStatusFk, request.ApprovalStatusFk, request.SoldAmount, request.ActionDate, request.IsActive);

        await _unitOfWork.AssetItemScrapRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetItemScrapNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.AssetCount.Commands;

public class CreateAssetCountCommand : ICommand<Result<int>>
{
        public string? AssetCountNumber { get; set; }
        public int? AssetTakerUserFk { get; set; }
        public DateTime? CountDate { get; set; }
        public int? ZoneFk { get; set; }
        public int? AssetCountPlanFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetCountCommandHandler : ICommandHandler<CreateAssetCountCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetCountCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetCountCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.AssetCount.Create(request.AssetCountNumber, request.AssetTakerUserFk, request.CountDate, request.ZoneFk, request.AssetCountPlanFk, request.IsActive);

        await _unitOfWork.AssetCountRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetCountNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.AssetCommissioning.Commands;

public class CreateAssetCommissioningCommand : ICommand<Result<int>>
{
        public int? AssetFk { get; set; }
        public int? CommissionConditionFk { get; set; }
        public int? AssetFunctionalityFk { get; set; }
        public int? AssetComplineFk { get; set; }
        public int? SubSectionFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetCommissioningCommandHandler : ICommandHandler<CreateAssetCommissioningCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetCommissioningCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetCommissioningCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.AssetCommissioning.Create(request.AssetFk, request.CommissionConditionFk, request.AssetFunctionalityFk, request.AssetComplineFk, request.SubSectionFk, request.IsActive);

        await _unitOfWork.AssetCommissioningRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetCommissioningNotInserted);
    }
}
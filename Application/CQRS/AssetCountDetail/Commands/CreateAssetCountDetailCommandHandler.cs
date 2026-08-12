using Application.Abstractions;

namespace Application.CQRS.AssetCountDetail.Commands;

public class CreateAssetCountDetailCommand : ICommand<Result<int>>
{
        public int? AssetCountFk { get; set; }
        public int? AssetFk { get; set; }
        public int? AssetCountStatusFk { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetCountDetailCommandHandler : ICommandHandler<CreateAssetCountDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetCountDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetCountDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.AssetCountDetail.Create(request.AssetCountFk, request.AssetFk, request.AssetCountStatusFk, request.Notes, request.IsActive);

        await _unitOfWork.AssetCountDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetCountDetailNotInserted);
    }
}
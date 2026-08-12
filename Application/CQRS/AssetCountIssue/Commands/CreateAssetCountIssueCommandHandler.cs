using Application.Abstractions;

namespace Application.CQRS.AssetCountIssue.Commands;

public class CreateAssetCountIssueCommand : ICommand<Result<int>>
{
        public string? IssueNumber { get; set; }
        public int? AssetCountDetailFk { get; set; }
        public int? AssetCountIssueStatusFk { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetCountIssueCommandHandler : ICommandHandler<CreateAssetCountIssueCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetCountIssueCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetCountIssueCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.AssetCountIssue.Create(request.IssueNumber, request.AssetCountDetailFk, request.AssetCountIssueStatusFk, request.Notes, request.IsActive);

        await _unitOfWork.AssetCountIssueRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetCountIssueNotInserted);
    }
}
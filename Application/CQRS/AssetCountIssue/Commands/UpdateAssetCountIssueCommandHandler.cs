using Application.Abstractions;

namespace Application.CQRS.AssetCountIssue.Commands;

public class UpdateAssetCountIssueCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? IssueNumber { get; set; }
        public int? AssetCountDetailFk { get; set; }
        public int? AssetCountIssueStatusFk { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetCountIssueCommandHandler : ICommandHandler<UpdateAssetCountIssueCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetCountIssueCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetCountIssueCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountIssueRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountIssueNotFound);

        entity.Update(request.IssueNumber, request.AssetCountDetailFk, request.AssetCountIssueStatusFk, request.Notes, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountIssueNotUpdated);
    }
}
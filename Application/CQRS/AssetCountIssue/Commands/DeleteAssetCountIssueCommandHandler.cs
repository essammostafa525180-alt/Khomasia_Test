using Application.Abstractions;

namespace Application.CQRS.AssetCountIssue.Commands;

public class DeleteAssetCountIssueCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetCountIssueCommandHandler : ICommandHandler<DeleteAssetCountIssueCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetCountIssueCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetCountIssueCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountIssueRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountIssueNotFound);

        _unitOfWork.AssetCountIssueRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountIssueNotDeleted);
    }
}
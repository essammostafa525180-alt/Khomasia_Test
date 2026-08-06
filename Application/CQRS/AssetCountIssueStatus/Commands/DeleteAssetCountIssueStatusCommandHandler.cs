using Application.Abstractions;

namespace Application.CQRS.AssetCountIssueStatus.Commands;

public class DeleteAssetCountIssueStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetCountIssueStatusCommandHandler : ICommandHandler<DeleteAssetCountIssueStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetCountIssueStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetCountIssueStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountIssueStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountIssueStatusNotFound);

        _unitOfWork.AssetCountIssueStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountIssueStatusNotDeleted);
    }
}
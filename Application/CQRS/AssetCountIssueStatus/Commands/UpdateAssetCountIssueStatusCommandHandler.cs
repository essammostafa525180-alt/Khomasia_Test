using Application.Abstractions;

namespace Application.CQRS.AssetCountIssueStatus.Commands;

public class UpdateAssetCountIssueStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetCountIssueStatusCommandHandler : ICommandHandler<UpdateAssetCountIssueStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetCountIssueStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetCountIssueStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountIssueStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountIssueStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountIssueStatusNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.AssetCountIssueStatus.Commands;

public class CreateAssetCountIssueStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetCountIssueStatusCommandHandler : ICommandHandler<CreateAssetCountIssueStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetCountIssueStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetCountIssueStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.AssetCountIssueStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.AssetCountIssueStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetCountIssueStatusNotInserted);
    }
}
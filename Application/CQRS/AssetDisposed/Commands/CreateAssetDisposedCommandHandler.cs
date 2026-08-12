using Application.Abstractions;

namespace Application.CQRS.AssetDisposed.Commands;

public class CreateAssetDisposedCommand : ICommand<Result<int>>
{
        public string? OrganizationName { get; set; }
        public decimal? Cost { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetDisposedCommandHandler : ICommandHandler<CreateAssetDisposedCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetDisposedCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetDisposedCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.AssetDisposed.Create(request.OrganizationName, request.Cost, request.Notes, request.IsActive);

        await _unitOfWork.AssetDisposedRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetDisposedNotInserted);
    }
}
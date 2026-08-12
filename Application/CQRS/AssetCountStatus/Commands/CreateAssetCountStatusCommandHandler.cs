using Application.Abstractions;

namespace Application.CQRS.AssetCountStatus.Commands;

public class CreateAssetCountStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetCountStatusCommandHandler : ICommandHandler<CreateAssetCountStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetCountStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetCountStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.AssetCountStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.AssetCountStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetCountStatusNotInserted);
    }
}
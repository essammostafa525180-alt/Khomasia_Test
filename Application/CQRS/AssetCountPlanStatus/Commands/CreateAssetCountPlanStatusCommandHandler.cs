using Application.Abstractions;

namespace Application.CQRS.AssetCountPlanStatus.Commands;

public class CreateAssetCountPlanStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetCountPlanStatusCommandHandler : ICommandHandler<CreateAssetCountPlanStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetCountPlanStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetCountPlanStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.AssetCountPlanStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.AssetCountPlanStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetCountPlanStatusNotInserted);
    }
}
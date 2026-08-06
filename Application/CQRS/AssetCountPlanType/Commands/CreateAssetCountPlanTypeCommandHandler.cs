using Application.Abstractions;

namespace Application.CQRS.AssetCountPlanType.Commands;

public class CreateAssetCountPlanTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetCountPlanTypeCommandHandler : ICommandHandler<CreateAssetCountPlanTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetCountPlanTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetCountPlanTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.AssetCountPlanType.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.AssetCountPlanTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetCountPlanTypeNotInserted);
    }
}
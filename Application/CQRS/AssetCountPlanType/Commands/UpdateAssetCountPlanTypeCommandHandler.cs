using Application.Abstractions;

namespace Application.CQRS.AssetCountPlanType.Commands;

public class UpdateAssetCountPlanTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetCountPlanTypeCommandHandler : ICommandHandler<UpdateAssetCountPlanTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetCountPlanTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetCountPlanTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountPlanTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountPlanTypeNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountPlanTypeNotUpdated);
    }
}
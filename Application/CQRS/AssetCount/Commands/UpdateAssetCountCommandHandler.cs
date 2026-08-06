using Application.Abstractions;

namespace Application.CQRS.AssetCount.Commands;

public class UpdateAssetCountCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? AssetCountNumber { get; set; }
        public int? AssetTakerUserFk { get; set; }
        public DateTime? CountDate { get; set; }
        public int? ZoneFk { get; set; }
        public int? AssetCountPlanFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetCountCommandHandler : ICommandHandler<UpdateAssetCountCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetCountCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetCountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountNotFound);

        entity.Update(request.AssetCountNumber, request.AssetTakerUserFk, request.CountDate, request.ZoneFk, request.AssetCountPlanFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountNotUpdated);
    }
}
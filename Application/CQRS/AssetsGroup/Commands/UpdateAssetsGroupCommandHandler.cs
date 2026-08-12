using Application.Abstractions;

namespace Application.CQRS.AssetsGroup.Commands;

public class UpdateAssetsGroupCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public decimal? DepreciationDuration { get; set; }
        public decimal? DepreciationRate { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetsGroupCommandHandler : ICommandHandler<UpdateAssetsGroupCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetsGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetsGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetsGroupRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetsGroupNotFound);

        entity.Update(request.Name, request.NameAr, request.DepreciationDuration, request.DepreciationRate, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetsGroupNotUpdated);
    }
}
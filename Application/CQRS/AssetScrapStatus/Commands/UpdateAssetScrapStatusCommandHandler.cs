using Application.Abstractions;

namespace Application.CQRS.AssetScrapStatus.Commands;

public class UpdateAssetScrapStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetScrapStatusCommandHandler : ICommandHandler<UpdateAssetScrapStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetScrapStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetScrapStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetScrapStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetScrapStatusNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetScrapStatusNotUpdated);
    }
}
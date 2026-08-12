using Application.Abstractions;

namespace Application.CQRS.AssetCompline.Commands;

public class UpdateAssetComplineCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetComplineCommandHandler : ICommandHandler<UpdateAssetComplineCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetComplineCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetComplineCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetComplineRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetComplineNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetComplineNotUpdated);
    }
}
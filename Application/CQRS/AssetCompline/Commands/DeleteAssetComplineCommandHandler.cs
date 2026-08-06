using Application.Abstractions;

namespace Application.CQRS.AssetCompline.Commands;

public class DeleteAssetComplineCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetComplineCommandHandler : ICommandHandler<DeleteAssetComplineCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetComplineCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetComplineCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetComplineRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetComplineNotFound);

        _unitOfWork.AssetComplineRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetComplineNotDeleted);
    }
}
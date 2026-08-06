using Application.Abstractions;

namespace Application.CQRS.AssetMoveType.Commands;

public class UpdateAssetMoveTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetMoveTypeCommandHandler : ICommandHandler<UpdateAssetMoveTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetMoveTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetMoveTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetMoveTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetMoveTypeNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetMoveTypeNotUpdated);
    }
}
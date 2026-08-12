using Application.Abstractions;

namespace Application.CQRS.AssetStatus.Commands;

public class UpdateAssetStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetStatusCommandHandler : ICommandHandler<UpdateAssetStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetStatusNotUpdated);
    }
}
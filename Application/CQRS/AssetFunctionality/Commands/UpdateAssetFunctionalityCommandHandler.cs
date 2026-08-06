using Application.Abstractions;

namespace Application.CQRS.AssetFunctionality.Commands;

public class UpdateAssetFunctionalityCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetFunctionalityCommandHandler : ICommandHandler<UpdateAssetFunctionalityCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetFunctionalityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetFunctionalityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetFunctionalityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetFunctionalityNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetFunctionalityNotUpdated);
    }
}
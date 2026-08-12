using Application.Abstractions;

namespace Application.CQRS.AssetWarrantyStatus.Commands;

public class UpdateAssetWarrantyStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetWarrantyStatusCommandHandler : ICommandHandler<UpdateAssetWarrantyStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetWarrantyStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetWarrantyStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetWarrantyStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetWarrantyStatusNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetWarrantyStatusNotUpdated);
    }
}
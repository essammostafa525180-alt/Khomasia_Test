using Application.Abstractions;

namespace Application.CQRS.AssetItemMove.Commands;

public class UpdateAssetItemMoveCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public int? AssetItemFk { get; set; }
        public int? AssetMoveTypeFk { get; set; }
        public int? FromProjectFk { get; set; }
        public int? FromAssetLocationFk { get; set; }
        public int? ToProjectFk { get; set; }
        public int? ToAssetLocationFk { get; set; }
        public int? EmployeeFk { get; set; }
        public DateOnly? MoveDate { get; set; }
        public int? OwnerApprovedFk { get; set; }
        public int? IsOwnerApprovedFk { get; set; }
        public DateTime? OwnerApprovedDate { get; set; }
        public int? ManagerApprovedFk { get; set; }
        public int? IsManagerApprovedFk { get; set; }
        public DateTime? ManagerApprovedDate { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetItemMoveCommandHandler : ICommandHandler<UpdateAssetItemMoveCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetItemMoveCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetItemMoveCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetItemMoveRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetItemMoveNotFound);

        entity.Update(request.Code, request.AssetItemFk, request.AssetMoveTypeFk, request.FromProjectFk, request.FromAssetLocationFk, request.ToProjectFk, request.ToAssetLocationFk, request.EmployeeFk, request.MoveDate, request.OwnerApprovedFk, request.IsOwnerApprovedFk, request.OwnerApprovedDate, request.ManagerApprovedFk, request.IsManagerApprovedFk, request.ManagerApprovedDate, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetItemMoveNotUpdated);
    }
}
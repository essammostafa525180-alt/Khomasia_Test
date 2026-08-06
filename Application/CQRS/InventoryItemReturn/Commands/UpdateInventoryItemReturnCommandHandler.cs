using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturn.Commands;

public class UpdateInventoryItemReturnCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? RequestWithdrawFk { get; set; }
        public string? ReturnNo { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? ReturnedByFk { get; set; }
        public string? ReturnedBy { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public int? ItemReturnStatusFk { get; set; }
        public bool? IsAprove { get; set; }
        public bool? Axsynced { get; set; }
        public int? SourceId { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemReturnCommandHandler : ICommandHandler<UpdateInventoryItemReturnCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemReturnCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemReturnCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemReturnNotFound);

        entity.Update(request.RequestWithdrawFk, request.ReturnNo, request.ReturnDate, request.ReturnedByFk, request.ReturnedBy, request.DescriptionEn, request.DescriptionAr, request.ItemReturnStatusFk, request.IsAprove, request.Axsynced, request.SourceId, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemReturnNotUpdated);
    }
}
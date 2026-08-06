using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturn.Commands;

public class CreateInventoryItemReturnCommand : ICommand<Result<int>>
{
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
internal class CreateInventoryItemReturnCommandHandler : ICommandHandler<CreateInventoryItemReturnCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemReturnCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemReturnCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemReturn.Create(request.RequestWithdrawFk, request.ReturnNo, request.ReturnDate, request.ReturnedByFk, request.ReturnedBy, request.DescriptionEn, request.DescriptionAr, request.ItemReturnStatusFk, request.IsAprove, request.Axsynced, request.SourceId, request.IsActive);

        await _unitOfWork.InventoryItemReturnRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemReturnNotInserted);
    }
}
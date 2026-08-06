using Application.Abstractions;

namespace Application.CQRS.RequestWithdrawSerial.Commands;

public class UpdateRequestWithdrawSerialCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? RequestWithdrawFk { get; set; }
        public int? RequestWithdrawDetailFk { get; set; }
        public int? RwDeliveredQuantityFk { get; set; }
        public int? InventoryItemSerialFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateRequestWithdrawSerialCommandHandler : ICommandHandler<UpdateRequestWithdrawSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRequestWithdrawSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateRequestWithdrawSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RequestWithdrawSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RequestWithdrawSerialNotFound);

        entity.Update(request.RequestWithdrawFk, request.RequestWithdrawDetailFk, request.RwDeliveredQuantityFk, request.InventoryItemSerialFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RequestWithdrawSerialNotUpdated);
    }
}
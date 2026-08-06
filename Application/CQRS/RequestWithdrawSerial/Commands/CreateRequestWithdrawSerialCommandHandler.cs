using Application.Abstractions;

namespace Application.CQRS.RequestWithdrawSerial.Commands;

public class CreateRequestWithdrawSerialCommand : ICommand<Result<int>>
{
        public int? RequestWithdrawFk { get; set; }
        public int? RequestWithdrawDetailFk { get; set; }
        public int? RwDeliveredQuantityFk { get; set; }
        public int? InventoryItemSerialFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateRequestWithdrawSerialCommandHandler : ICommandHandler<CreateRequestWithdrawSerialCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRequestWithdrawSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateRequestWithdrawSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.RequestAggregate.RequestWithdrawSerial.Create(request.RequestWithdrawFk, request.RequestWithdrawDetailFk, request.RwDeliveredQuantityFk, request.InventoryItemSerialFk, request.IsActive);

        await _unitOfWork.RequestWithdrawSerialRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.RequestWithdrawSerialNotInserted);
    }
}
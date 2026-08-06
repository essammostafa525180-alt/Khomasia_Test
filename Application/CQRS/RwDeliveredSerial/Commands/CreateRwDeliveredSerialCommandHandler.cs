using Application.Abstractions;

namespace Application.CQRS.RwDeliveredSerial.Commands;

public class CreateRwDeliveredSerialCommand : ICommand<Result<int>>
{
        public int? RwDeliveredBatchFk { get; set; }
        public int? SerialFk { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateRwDeliveredSerialCommandHandler : ICommandHandler<CreateRwDeliveredSerialCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRwDeliveredSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateRwDeliveredSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.RequestAggregate.RwDeliveredSerial.Create(request.RwDeliveredBatchFk, request.SerialFk, request.Axsynced, request.IsActive);

        await _unitOfWork.RwDeliveredSerialRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.RwDeliveredSerialNotInserted);
    }
}
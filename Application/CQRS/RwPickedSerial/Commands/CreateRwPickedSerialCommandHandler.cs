using Application.Abstractions;

namespace Application.CQRS.RwPickedSerial.Commands;

public class CreateRwPickedSerialCommand : ICommand<Result<int>>
{
        public int? RwPickedBatchFk { get; set; }
        public int? SerialFk { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateRwPickedSerialCommandHandler : ICommandHandler<CreateRwPickedSerialCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRwPickedSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateRwPickedSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.RequestAggregate.RwPickedSerial.Create(request.RwPickedBatchFk, request.SerialFk, request.Axsynced, request.IsActive);

        await _unitOfWork.RwPickedSerialRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.RwPickedSerialNotInserted);
    }
}
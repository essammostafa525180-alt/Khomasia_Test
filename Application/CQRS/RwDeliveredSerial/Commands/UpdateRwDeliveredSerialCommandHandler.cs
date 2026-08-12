using Application.Abstractions;

namespace Application.CQRS.RwDeliveredSerial.Commands;

public class UpdateRwDeliveredSerialCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? RwDeliveredBatchFk { get; set; }
        public int? SerialFk { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateRwDeliveredSerialCommandHandler : ICommandHandler<UpdateRwDeliveredSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRwDeliveredSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateRwDeliveredSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwDeliveredSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RwDeliveredSerialNotFound);

        entity.Update(request.RwDeliveredBatchFk, request.SerialFk, request.Axsynced, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RwDeliveredSerialNotUpdated);
    }
}
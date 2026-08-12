using Application.Abstractions;

namespace Application.CQRS.RwPickedSerial.Commands;

public class UpdateRwPickedSerialCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? RwPickedBatchFk { get; set; }
        public int? SerialFk { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateRwPickedSerialCommandHandler : ICommandHandler<UpdateRwPickedSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRwPickedSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateRwPickedSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwPickedSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RwPickedSerialNotFound);

        entity.Update(request.RwPickedBatchFk, request.SerialFk, request.Axsynced, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RwPickedSerialNotUpdated);
    }
}
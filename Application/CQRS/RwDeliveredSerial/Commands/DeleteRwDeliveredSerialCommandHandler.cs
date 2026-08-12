using Application.Abstractions;

namespace Application.CQRS.RwDeliveredSerial.Commands;

public class DeleteRwDeliveredSerialCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteRwDeliveredSerialCommandHandler : ICommandHandler<DeleteRwDeliveredSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRwDeliveredSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteRwDeliveredSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwDeliveredSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RwDeliveredSerialNotFound);

        _unitOfWork.RwDeliveredSerialRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RwDeliveredSerialNotDeleted);
    }
}
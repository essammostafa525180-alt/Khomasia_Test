using Application.Abstractions;

namespace Application.CQRS.RwPickedSerial.Commands;

public class DeleteRwPickedSerialCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteRwPickedSerialCommandHandler : ICommandHandler<DeleteRwPickedSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRwPickedSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteRwPickedSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwPickedSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RwPickedSerialNotFound);

        _unitOfWork.RwPickedSerialRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RwPickedSerialNotDeleted);
    }
}
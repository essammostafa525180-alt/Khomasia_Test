using Application.Abstractions;

namespace Application.CQRS.TransmissionType.Commands;

public class DeleteTransmissionTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteTransmissionTypeCommandHandler : ICommandHandler<DeleteTransmissionTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTransmissionTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteTransmissionTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TransmissionTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.TransmissionTypeNotFound);

        _unitOfWork.TransmissionTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.TransmissionTypeNotDeleted);
    }
}
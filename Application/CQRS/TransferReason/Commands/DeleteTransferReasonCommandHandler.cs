using Application.Abstractions;

namespace Application.CQRS.TransferReason.Commands;

public class DeleteTransferReasonCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteTransferReasonCommandHandler : ICommandHandler<DeleteTransferReasonCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTransferReasonCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteTransferReasonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TransferReasonRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.TransferReasonNotFound);

        _unitOfWork.TransferReasonRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.TransferReasonNotDeleted);
    }
}
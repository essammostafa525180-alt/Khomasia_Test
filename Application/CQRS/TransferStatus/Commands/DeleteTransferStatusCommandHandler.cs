using Application.Abstractions;

namespace Application.CQRS.TransferStatus.Commands;

public class DeleteTransferStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteTransferStatusCommandHandler : ICommandHandler<DeleteTransferStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTransferStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteTransferStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TransferStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.TransferStatusNotFound);

        _unitOfWork.TransferStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.TransferStatusNotDeleted);
    }
}
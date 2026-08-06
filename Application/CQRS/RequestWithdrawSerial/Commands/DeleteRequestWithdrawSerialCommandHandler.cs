using Application.Abstractions;

namespace Application.CQRS.RequestWithdrawSerial.Commands;

public class DeleteRequestWithdrawSerialCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteRequestWithdrawSerialCommandHandler : ICommandHandler<DeleteRequestWithdrawSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRequestWithdrawSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteRequestWithdrawSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RequestWithdrawSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RequestWithdrawSerialNotFound);

        _unitOfWork.RequestWithdrawSerialRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RequestWithdrawSerialNotDeleted);
    }
}
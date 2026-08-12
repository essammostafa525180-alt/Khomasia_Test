using Application.Abstractions;

namespace Application.CQRS.InventroyItemRequestWithdraw.Commands;

public class DeleteInventroyItemRequestWithdrawCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventroyItemRequestWithdrawCommandHandler : ICommandHandler<DeleteInventroyItemRequestWithdrawCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventroyItemRequestWithdrawCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventroyItemRequestWithdrawCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventroyItemRequestWithdrawRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventroyItemRequestWithdrawNotFound);

        _unitOfWork.InventroyItemRequestWithdrawRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventroyItemRequestWithdrawNotDeleted);
    }
}
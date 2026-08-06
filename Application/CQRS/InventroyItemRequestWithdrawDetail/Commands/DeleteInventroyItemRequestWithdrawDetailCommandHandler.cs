using Application.Abstractions;

namespace Application.CQRS.InventroyItemRequestWithdrawDetail.Commands;

public class DeleteInventroyItemRequestWithdrawDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventroyItemRequestWithdrawDetailCommandHandler : ICommandHandler<DeleteInventroyItemRequestWithdrawDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventroyItemRequestWithdrawDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventroyItemRequestWithdrawDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventroyItemRequestWithdrawDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventroyItemRequestWithdrawDetailNotFound);

        _unitOfWork.InventroyItemRequestWithdrawDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventroyItemRequestWithdrawDetailNotDeleted);
    }
}
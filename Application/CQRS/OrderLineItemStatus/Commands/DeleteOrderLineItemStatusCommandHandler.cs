using Application.Abstractions;

namespace Application.CQRS.OrderLineItemStatus.Commands;

public class DeleteOrderLineItemStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteOrderLineItemStatusCommandHandler : ICommandHandler<DeleteOrderLineItemStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOrderLineItemStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteOrderLineItemStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.OrderLineItemStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.OrderLineItemStatusNotFound);

        _unitOfWork.OrderLineItemStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.OrderLineItemStatusNotDeleted);
    }
}
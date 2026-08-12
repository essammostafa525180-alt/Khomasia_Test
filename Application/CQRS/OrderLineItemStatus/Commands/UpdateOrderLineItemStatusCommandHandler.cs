using Application.Abstractions;

namespace Application.CQRS.OrderLineItemStatus.Commands;

public class UpdateOrderLineItemStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateOrderLineItemStatusCommandHandler : ICommandHandler<UpdateOrderLineItemStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOrderLineItemStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateOrderLineItemStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.OrderLineItemStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.OrderLineItemStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.OrderLineItemStatusNotUpdated);
    }
}
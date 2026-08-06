using Application.Abstractions;

namespace Application.CQRS.OrderLineItemStatus.Commands;

public class CreateOrderLineItemStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateOrderLineItemStatusCommandHandler : ICommandHandler<CreateOrderLineItemStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderLineItemStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateOrderLineItemStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.OrderLineItemStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.OrderLineItemStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.OrderLineItemStatusNotInserted);
    }
}
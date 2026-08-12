using Application.Abstractions;

namespace Application.CQRS.VendorOrder.Commands;

public class CreateVendorOrderCommand : ICommand<Result<int>>
{
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderCommandHandler : ICommandHandler<CreateVendorOrderCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.VendorOrder.Create(request.IsActive);

        await _unitOfWork.VendorOrderRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderNotInserted);
    }
}
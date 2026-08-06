using Application.Abstractions;

namespace Application.CQRS.VendorOrderDetail.Commands;

public class CreateVendorOrderDetailCommand : ICommand<Result<int>>
{
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderDetailCommandHandler : ICommandHandler<CreateVendorOrderDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.VendorOrderDetail.Create(request.IsActive);

        await _unitOfWork.VendorOrderDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderDetailNotInserted);
    }
}
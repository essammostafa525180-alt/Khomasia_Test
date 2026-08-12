using Application.Abstractions;

namespace Application.CQRS.VendorOrder.Commands;

public class DeleteVendorOrderCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderCommandHandler : ICommandHandler<DeleteVendorOrderCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderNotFound);

        _unitOfWork.VendorOrderRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.VendorOrderDetail.Commands;

public class DeleteVendorOrderDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderDetailCommandHandler : ICommandHandler<DeleteVendorOrderDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderDetailNotFound);

        _unitOfWork.VendorOrderDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderDetailNotDeleted);
    }
}
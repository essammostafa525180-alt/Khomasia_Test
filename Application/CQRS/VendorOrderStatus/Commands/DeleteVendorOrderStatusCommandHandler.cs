using Application.Abstractions;

namespace Application.CQRS.VendorOrderStatus.Commands;

public class DeleteVendorOrderStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderStatusCommandHandler : ICommandHandler<DeleteVendorOrderStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderStatusNotFound);

        _unitOfWork.VendorOrderStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderStatusNotDeleted);
    }
}
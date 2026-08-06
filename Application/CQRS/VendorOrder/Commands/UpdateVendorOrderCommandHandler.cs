using Application.Abstractions;

namespace Application.CQRS.VendorOrder.Commands;

public class UpdateVendorOrderCommand : ICommand<Result>
{
        public int Id { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderCommandHandler : ICommandHandler<UpdateVendorOrderCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderNotFound);

        entity.Update(request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderNotUpdated);
    }
}
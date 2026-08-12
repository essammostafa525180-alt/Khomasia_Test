using Application.Abstractions;

namespace Application.CQRS.VendorOrderDetail.Commands;

public class UpdateVendorOrderDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderDetailCommandHandler : ICommandHandler<UpdateVendorOrderDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderDetailNotFound);

        entity.Update(request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderDetailNotUpdated);
    }
}
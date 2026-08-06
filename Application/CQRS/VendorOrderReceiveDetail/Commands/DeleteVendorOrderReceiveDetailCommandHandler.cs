using Application.Abstractions;

namespace Application.CQRS.VendorOrderReceiveDetail.Commands;

public class DeleteVendorOrderReceiveDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderReceiveDetailCommandHandler : ICommandHandler<DeleteVendorOrderReceiveDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderReceiveDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderReceiveDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderReceiveDetailNotFound);

        _unitOfWork.VendorOrderReceiveDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderReceiveDetailNotDeleted);
    }
}
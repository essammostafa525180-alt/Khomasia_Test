using Application.Abstractions;

namespace Application.CQRS.VendorOrderVendorSelection.Commands;

public class DeleteVendorOrderVendorSelectionCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderVendorSelectionCommandHandler : ICommandHandler<DeleteVendorOrderVendorSelectionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderVendorSelectionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderVendorSelectionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderVendorSelectionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderVendorSelectionNotFound);

        _unitOfWork.VendorOrderVendorSelectionRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderVendorSelectionNotDeleted);
    }
}
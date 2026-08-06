using Application.Abstractions;

namespace Application.CQRS.VendorOrderType.Commands;

public class DeleteVendorOrderTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderTypeCommandHandler : ICommandHandler<DeleteVendorOrderTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderTypeNotFound);

        _unitOfWork.VendorOrderTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderTypeNotDeleted);
    }
}
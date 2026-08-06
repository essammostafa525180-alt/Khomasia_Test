using Application.Abstractions;

namespace Application.CQRS.VendorType.Commands;

public class DeleteVendorTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorTypeCommandHandler : ICommandHandler<DeleteVendorTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorTypeNotFound);

        _unitOfWork.VendorTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorTypeNotDeleted);
    }
}
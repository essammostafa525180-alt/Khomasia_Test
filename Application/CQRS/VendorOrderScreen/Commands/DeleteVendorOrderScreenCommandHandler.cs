using Application.Abstractions;

namespace Application.CQRS.VendorOrderScreen.Commands;

public class DeleteVendorOrderScreenCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderScreenCommandHandler : ICommandHandler<DeleteVendorOrderScreenCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderScreenCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderScreenCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderScreenRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderScreenNotFound);

        _unitOfWork.VendorOrderScreenRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderScreenNotDeleted);
    }
}
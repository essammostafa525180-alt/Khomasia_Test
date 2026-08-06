using Application.Abstractions;

namespace Application.CQRS.VendorStatus.Commands;

public class DeleteVendorStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorStatusCommandHandler : ICommandHandler<DeleteVendorStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorStatusNotFound);

        _unitOfWork.VendorStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorStatusNotDeleted);
    }
}
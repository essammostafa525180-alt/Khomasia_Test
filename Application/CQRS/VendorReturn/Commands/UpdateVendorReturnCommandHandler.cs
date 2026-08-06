using Application.Abstractions;

namespace Application.CQRS.VendorReturn.Commands;

public class UpdateVendorReturnCommand : ICommand<Result>
{
        public int Id { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorReturnCommandHandler : ICommandHandler<UpdateVendorReturnCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorReturnCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorReturnCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorReturnNotFound);

        entity.Update(request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorReturnNotUpdated);
    }
}
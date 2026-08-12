using Application.Abstractions;

namespace Application.CQRS.VendorOrderVendorSuggested.Commands;

public class DeleteVendorOrderVendorSuggestedCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderVendorSuggestedCommandHandler : ICommandHandler<DeleteVendorOrderVendorSuggestedCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderVendorSuggestedCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderVendorSuggestedCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderVendorSuggestedRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderVendorSuggestedNotFound);

        _unitOfWork.VendorOrderVendorSuggestedRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderVendorSuggestedNotDeleted);
    }
}
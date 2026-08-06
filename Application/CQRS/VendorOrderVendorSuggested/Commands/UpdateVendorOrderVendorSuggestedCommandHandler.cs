using Application.Abstractions;

namespace Application.CQRS.VendorOrderVendorSuggested.Commands;

public class UpdateVendorOrderVendorSuggestedCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorOrderFk { get; set; }
        public string? VendorName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderVendorSuggestedCommandHandler : ICommandHandler<UpdateVendorOrderVendorSuggestedCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderVendorSuggestedCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderVendorSuggestedCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderVendorSuggestedRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderVendorSuggestedNotFound);

        entity.Update(request.VendorOrderFk, request.VendorName, request.Address, request.Phone, request.Email, request.Website, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderVendorSuggestedNotUpdated);
    }
}
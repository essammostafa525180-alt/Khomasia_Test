using Application.Abstractions;

namespace Application.CQRS.VendorOrderVendorSelection.Commands;

public class UpdateVendorOrderVendorSelectionCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorOrderFk { get; set; }
        public int? VendorFk { get; set; }
        public bool IsSelected { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderVendorSelectionCommandHandler : ICommandHandler<UpdateVendorOrderVendorSelectionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderVendorSelectionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderVendorSelectionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderVendorSelectionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderVendorSelectionNotFound);

        entity.Update(request.VendorOrderFk, request.VendorFk, request.IsSelected, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderVendorSelectionNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.VendorOrderPartiallyReceivedNote.Commands;

public class UpdateVendorOrderPartiallyReceivedNoteCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorOrderDetailFk { get; set; }
        public int? PartiallyReceivedReasonFk { get; set; }
        public decimal? CurrentReceivedQuantity { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderPartiallyReceivedNoteCommandHandler : ICommandHandler<UpdateVendorOrderPartiallyReceivedNoteCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderPartiallyReceivedNoteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderPartiallyReceivedNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderPartiallyReceivedNoteRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderPartiallyReceivedNoteNotFound);

        entity.Update(request.VendorOrderDetailFk, request.PartiallyReceivedReasonFk, request.CurrentReceivedQuantity, request.Notes, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderPartiallyReceivedNoteNotUpdated);
    }
}
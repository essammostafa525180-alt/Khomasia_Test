using Application.Abstractions;

namespace Application.CQRS.VendorOrderPartiallyReceivedNote.Commands;

public class CreateVendorOrderPartiallyReceivedNoteCommand : ICommand<Result<int>>
{
        public int? VendorOrderDetailFk { get; set; }
        public int? PartiallyReceivedReasonFk { get; set; }
        public decimal? CurrentReceivedQuantity { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderPartiallyReceivedNoteCommandHandler : ICommandHandler<CreateVendorOrderPartiallyReceivedNoteCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderPartiallyReceivedNoteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderPartiallyReceivedNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.VendorOrderPartiallyReceivedNote.Create(request.VendorOrderDetailFk, request.PartiallyReceivedReasonFk, request.CurrentReceivedQuantity, request.Notes, request.IsActive);

        await _unitOfWork.VendorOrderPartiallyReceivedNoteRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderPartiallyReceivedNoteNotInserted);
    }
}
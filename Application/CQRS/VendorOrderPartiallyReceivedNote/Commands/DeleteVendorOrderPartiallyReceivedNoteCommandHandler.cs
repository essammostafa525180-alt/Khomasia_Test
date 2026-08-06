using Application.Abstractions;

namespace Application.CQRS.VendorOrderPartiallyReceivedNote.Commands;

public class DeleteVendorOrderPartiallyReceivedNoteCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderPartiallyReceivedNoteCommandHandler : ICommandHandler<DeleteVendorOrderPartiallyReceivedNoteCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderPartiallyReceivedNoteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderPartiallyReceivedNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderPartiallyReceivedNoteRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderPartiallyReceivedNoteNotFound);

        _unitOfWork.VendorOrderPartiallyReceivedNoteRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderPartiallyReceivedNoteNotDeleted);
    }
}
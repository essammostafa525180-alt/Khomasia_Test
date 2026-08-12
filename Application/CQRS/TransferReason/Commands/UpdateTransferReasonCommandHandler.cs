using Application.Abstractions;

namespace Application.CQRS.TransferReason.Commands;

public class UpdateTransferReasonCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateTransferReasonCommandHandler : ICommandHandler<UpdateTransferReasonCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTransferReasonCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateTransferReasonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TransferReasonRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.TransferReasonNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.TransferReasonNotUpdated);
    }
}
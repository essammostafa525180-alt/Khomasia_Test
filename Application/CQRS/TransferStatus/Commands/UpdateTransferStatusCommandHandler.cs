using Application.Abstractions;

namespace Application.CQRS.TransferStatus.Commands;

public class UpdateTransferStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateTransferStatusCommandHandler : ICommandHandler<UpdateTransferStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTransferStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateTransferStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TransferStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.TransferStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.TransferStatusNotUpdated);
    }
}
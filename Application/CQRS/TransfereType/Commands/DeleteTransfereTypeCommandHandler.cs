using Application.Abstractions;

namespace Application.CQRS.TransfereType.Commands;

public class DeleteTransfereTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteTransfereTypeCommandHandler : ICommandHandler<DeleteTransfereTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTransfereTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteTransfereTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TransfereTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.TransfereTypeNotFound);

        _unitOfWork.TransfereTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.TransfereTypeNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.StoreSequence.Commands;

public class DeleteStoreSequenceCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteStoreSequenceCommandHandler : ICommandHandler<DeleteStoreSequenceCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStoreSequenceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteStoreSequenceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StoreSequenceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.StoreSequenceNotFound);

        _unitOfWork.StoreSequenceRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.StoreSequenceNotDeleted);
    }
}
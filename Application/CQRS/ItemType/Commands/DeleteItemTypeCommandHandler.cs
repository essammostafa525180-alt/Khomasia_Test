using Application.Abstractions;

namespace Application.CQRS.ItemType.Commands;

public class DeleteItemTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteItemTypeCommandHandler : ICommandHandler<DeleteItemTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteItemTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteItemTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ItemTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ItemTypeNotFound);

        _unitOfWork.ItemTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ItemTypeNotDeleted);
    }
}
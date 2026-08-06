using Application.Abstractions;

namespace Application.CQRS.ItemExpiryType.Commands;

public class DeleteItemExpiryTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteItemExpiryTypeCommandHandler : ICommandHandler<DeleteItemExpiryTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteItemExpiryTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteItemExpiryTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ItemExpiryTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ItemExpiryTypeNotFound);

        _unitOfWork.ItemExpiryTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ItemExpiryTypeNotDeleted);
    }
}
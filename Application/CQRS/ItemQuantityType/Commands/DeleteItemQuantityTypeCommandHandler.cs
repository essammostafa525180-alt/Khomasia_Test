using Application.Abstractions;

namespace Application.CQRS.ItemQuantityType.Commands;

public class DeleteItemQuantityTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteItemQuantityTypeCommandHandler : ICommandHandler<DeleteItemQuantityTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteItemQuantityTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteItemQuantityTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ItemQuantityTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ItemQuantityTypeNotFound);

        _unitOfWork.ItemQuantityTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ItemQuantityTypeNotDeleted);
    }
}
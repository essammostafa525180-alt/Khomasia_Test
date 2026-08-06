using Application.Abstractions;

namespace Application.CQRS.RwDeliveredQuantity.Commands;

public class DeleteRwDeliveredQuantityCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteRwDeliveredQuantityCommandHandler : ICommandHandler<DeleteRwDeliveredQuantityCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRwDeliveredQuantityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteRwDeliveredQuantityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwDeliveredQuantityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RwDeliveredQuantityNotFound);

        _unitOfWork.RwDeliveredQuantityRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RwDeliveredQuantityNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.InventoryCurrency.Commands;

public class DeleteInventoryCurrencyCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryCurrencyCommandHandler : ICommandHandler<DeleteInventoryCurrencyCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryCurrencyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryCurrencyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryCurrencyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryCurrencyNotFound);

        _unitOfWork.InventoryCurrencyRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryCurrencyNotDeleted);
    }
}
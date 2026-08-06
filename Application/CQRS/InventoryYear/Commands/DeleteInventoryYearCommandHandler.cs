using Application.Abstractions;

namespace Application.CQRS.InventoryYear.Commands;

public class DeleteInventoryYearCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryYearCommandHandler : ICommandHandler<DeleteInventoryYearCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryYearCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryYearCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryYearRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryYearNotFound);

        _unitOfWork.InventoryYearRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryYearNotDeleted);
    }
}
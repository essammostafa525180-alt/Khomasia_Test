using Application.Abstractions;

namespace Application.CQRS.AnnualStockCountItemMerge.Commands;

public class DeleteAnnualStockCountItemMergeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAnnualStockCountItemMergeCommandHandler : ICommandHandler<DeleteAnnualStockCountItemMergeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAnnualStockCountItemMergeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAnnualStockCountItemMergeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AnnualStockCountItemMergeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AnnualStockCountItemMergeNotFound);

        _unitOfWork.AnnualStockCountItemMergeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AnnualStockCountItemMergeNotDeleted);
    }
}
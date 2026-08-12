using Application.Abstractions;

namespace Application.CQRS.AnnualStockCount.Commands;

public class DeleteAnnualStockCountCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAnnualStockCountCommandHandler : ICommandHandler<DeleteAnnualStockCountCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAnnualStockCountCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAnnualStockCountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AnnualStockCountRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AnnualStockCountNotFound);

        _unitOfWork.AnnualStockCountRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AnnualStockCountNotDeleted);
    }
}
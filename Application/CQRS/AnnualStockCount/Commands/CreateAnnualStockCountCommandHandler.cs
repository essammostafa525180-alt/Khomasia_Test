using Application.Abstractions;

namespace Application.CQRS.AnnualStockCount.Commands;

public class CreateAnnualStockCountCommand : ICommand<Result<int>>
{
        public int? YearId { get; set; }
        public int? StoreFk { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAnnualStockCountCommandHandler : ICommandHandler<CreateAnnualStockCountCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAnnualStockCountCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAnnualStockCountCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryStockCountAggregate.AnnualStockCount.Create(request.YearId, request.StoreFk, request.IsCompleted, request.IsActive);

        await _unitOfWork.AnnualStockCountRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AnnualStockCountNotInserted);
    }
}
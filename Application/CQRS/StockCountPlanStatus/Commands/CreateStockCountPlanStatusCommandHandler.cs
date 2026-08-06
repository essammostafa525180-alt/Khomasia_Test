using Application.Abstractions;

namespace Application.CQRS.StockCountPlanStatus.Commands;

public class CreateStockCountPlanStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateStockCountPlanStatusCommandHandler : ICommandHandler<CreateStockCountPlanStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStockCountPlanStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateStockCountPlanStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.StockCountPlanStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.StockCountPlanStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.StockCountPlanStatusNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.StockCountPlanType.Commands;

public class CreateStockCountPlanTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateStockCountPlanTypeCommandHandler : ICommandHandler<CreateStockCountPlanTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStockCountPlanTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateStockCountPlanTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.StockCountPlanType.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.StockCountPlanTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.StockCountPlanTypeNotInserted);
    }
}
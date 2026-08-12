using Application.Abstractions;

namespace Application.CQRS.RwDeliveredQuantity.Commands;

public class CreateRwDeliveredQuantityCommand : ICommand<Result<int>>
{
        public int? RequestWdfk { get; set; }
        public decimal? DeliveredQuantity { get; set; }
        public decimal? ScrapedQuantity { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public bool? Axsynced { get; set; }
        public bool? IsReceived { get; set; }
        public decimal? MaintainableQuantity { get; set; }
        public string? DeliveredNumber { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateRwDeliveredQuantityCommandHandler : ICommandHandler<CreateRwDeliveredQuantityCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRwDeliveredQuantityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateRwDeliveredQuantityCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.RequestAggregate.RwDeliveredQuantity.Create(request.RequestWdfk, request.DeliveredQuantity, request.ScrapedQuantity, request.DeliveredDate, request.Axsynced, request.IsReceived, request.MaintainableQuantity, request.DeliveredNumber, request.IsActive);

        await _unitOfWork.RwDeliveredQuantityRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.RwDeliveredQuantityNotInserted);
    }
}
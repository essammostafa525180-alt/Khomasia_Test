using Application.Abstractions;

namespace Application.CQRS.RwDeliveredQuantity.Commands;

public class UpdateRwDeliveredQuantityCommand : ICommand<Result>
{
        public int Id { get; set; }
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
internal class UpdateRwDeliveredQuantityCommandHandler : ICommandHandler<UpdateRwDeliveredQuantityCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRwDeliveredQuantityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateRwDeliveredQuantityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwDeliveredQuantityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RwDeliveredQuantityNotFound);

        entity.Update(request.RequestWdfk, request.DeliveredQuantity, request.ScrapedQuantity, request.DeliveredDate, request.Axsynced, request.IsReceived, request.MaintainableQuantity, request.DeliveredNumber, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RwDeliveredQuantityNotUpdated);
    }
}
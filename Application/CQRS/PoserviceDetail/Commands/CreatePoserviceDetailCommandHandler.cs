using Application.Abstractions;

namespace Application.CQRS.PoserviceDetail.Commands;

public class CreatePoserviceDetailCommand : ICommand<Result<int>>
{
        public int? PoserviceFk { get; set; }
        public int? ServiceTypeFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? ServiceCategoryFk { get; set; }
        public int? ServiceSubCategoryFk { get; set; }
        public int? ServiceFk { get; set; }
        public int? Quantity { get; set; }
        public decimal? CostPerService { get; set; }
        public decimal? TotalCost { get; set; }
        public int? ContractServiceId { get; set; }
        public bool IsActive { get; set; }
}
internal class CreatePoserviceDetailCommandHandler : ICommandHandler<CreatePoserviceDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePoserviceDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreatePoserviceDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.PoserviceDetail.Create(request.PoserviceFk, request.ServiceTypeFk, request.ServiceMainCategoryFk, request.ServiceCategoryFk, request.ServiceSubCategoryFk, request.ServiceFk, request.Quantity, request.CostPerService, request.TotalCost, request.ContractServiceId, request.IsActive);

        await _unitOfWork.PoserviceDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.PoserviceDetailNotInserted);
    }
}
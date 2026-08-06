using Application.Abstractions;

namespace Application.CQRS.PoserviceDetail.Commands;

public class UpdatePoserviceDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
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
internal class UpdatePoserviceDetailCommandHandler : ICommandHandler<UpdatePoserviceDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePoserviceDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePoserviceDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PoserviceDetailNotFound);

        entity.Update(request.PoserviceFk, request.ServiceTypeFk, request.ServiceMainCategoryFk, request.ServiceCategoryFk, request.ServiceSubCategoryFk, request.ServiceFk, request.Quantity, request.CostPerService, request.TotalCost, request.ContractServiceId, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PoserviceDetailNotUpdated);
    }
}
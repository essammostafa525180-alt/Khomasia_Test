using Application.Abstractions;

namespace Application.CQRS.PoserviceOutsource.Commands;

public class CreatePoserviceOutsourceCommand : ICommand<Result<int>>
{
        public int? PoserviceFk { get; set; }
        public int? WorkerTypeFk { get; set; }
        public int? EmployeeJobFk { get; set; }
        public int? Quantity { get; set; }
        public decimal? CostPerDay { get; set; }
        public decimal? TotalCost { get; set; }
        public int? ContractTaskEmployeeId { get; set; }
        public bool IsActive { get; set; }
}
internal class CreatePoserviceOutsourceCommandHandler : ICommandHandler<CreatePoserviceOutsourceCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePoserviceOutsourceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreatePoserviceOutsourceCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.PoserviceOutsource.Create(request.PoserviceFk, request.WorkerTypeFk, request.EmployeeJobFk, request.Quantity, request.CostPerDay, request.TotalCost, request.ContractTaskEmployeeId, request.IsActive);

        await _unitOfWork.PoserviceOutsourceRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.PoserviceOutsourceNotInserted);
    }
}
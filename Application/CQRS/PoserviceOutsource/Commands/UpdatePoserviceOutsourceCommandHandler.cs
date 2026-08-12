using Application.Abstractions;

namespace Application.CQRS.PoserviceOutsource.Commands;

public class UpdatePoserviceOutsourceCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? PoserviceFk { get; set; }
        public int? WorkerTypeFk { get; set; }
        public int? EmployeeJobFk { get; set; }
        public int? Quantity { get; set; }
        public decimal? CostPerDay { get; set; }
        public decimal? TotalCost { get; set; }
        public int? ContractTaskEmployeeId { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdatePoserviceOutsourceCommandHandler : ICommandHandler<UpdatePoserviceOutsourceCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePoserviceOutsourceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePoserviceOutsourceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceOutsourceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PoserviceOutsourceNotFound);

        entity.Update(request.PoserviceFk, request.WorkerTypeFk, request.EmployeeJobFk, request.Quantity, request.CostPerDay, request.TotalCost, request.ContractTaskEmployeeId, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PoserviceOutsourceNotUpdated);
    }
}
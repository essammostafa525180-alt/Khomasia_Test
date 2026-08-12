using Application.Abstractions;

namespace Application.CQRS.CostCenter.Commands;

public class UpdateCostCenterCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateCostCenterCommandHandler : ICommandHandler<UpdateCostCenterCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCostCenterCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateCostCenterCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CostCenterRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.CostCenterNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.CostCenterNotUpdated);
    }
}
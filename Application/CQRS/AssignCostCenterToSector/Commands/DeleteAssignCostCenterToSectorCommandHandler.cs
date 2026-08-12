using Application.Abstractions;

namespace Application.CQRS.AssignCostCenterToSector.Commands;

public class DeleteAssignCostCenterToSectorCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssignCostCenterToSectorCommandHandler : ICommandHandler<DeleteAssignCostCenterToSectorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssignCostCenterToSectorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssignCostCenterToSectorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssignCostCenterToSectorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssignCostCenterToSectorNotFound);

        _unitOfWork.AssignCostCenterToSectorRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssignCostCenterToSectorNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.UnitOfMeasure.Commands;

public class DeleteUnitOfMeasureCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteUnitOfMeasureCommandHandler : ICommandHandler<DeleteUnitOfMeasureCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUnitOfMeasureCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteUnitOfMeasureCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.UnitOfMeasureRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.UnitOfMeasureNotFound);

        _unitOfWork.UnitOfMeasureRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.UnitOfMeasureNotDeleted);
    }
}
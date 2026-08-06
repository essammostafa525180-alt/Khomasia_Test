using Application.Abstractions;

namespace Application.CQRS.DaysOfWeek.Commands;

public class DeleteDaysOfWeekCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteDaysOfWeekCommandHandler : ICommandHandler<DeleteDaysOfWeekCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDaysOfWeekCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteDaysOfWeekCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.DaysOfWeekRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.DaysOfWeekNotFound);

        _unitOfWork.DaysOfWeekRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.DaysOfWeekNotDeleted);
    }
}
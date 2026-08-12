using Application.Abstractions;

namespace Application.CQRS.DaysOfWeek.Commands;

public class UpdateDaysOfWeekCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateDaysOfWeekCommandHandler : ICommandHandler<UpdateDaysOfWeekCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDaysOfWeekCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateDaysOfWeekCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.DaysOfWeekRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.DaysOfWeekNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.DaysOfWeekNotUpdated);
    }
}
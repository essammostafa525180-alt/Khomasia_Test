using Application.Abstractions;

namespace Application.CQRS.DaysOfWeek.Commands;

public class CreateDaysOfWeekCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateDaysOfWeekCommandHandler : ICommandHandler<CreateDaysOfWeekCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDaysOfWeekCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateDaysOfWeekCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.DaysOfWeek.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.DaysOfWeekRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.DaysOfWeekNotInserted);
    }
}
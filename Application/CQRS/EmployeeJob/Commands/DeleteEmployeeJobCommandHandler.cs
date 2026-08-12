using Application.Abstractions;

namespace Application.CQRS.EmployeeJob.Commands;

public class DeleteEmployeeJobCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteEmployeeJobCommandHandler : ICommandHandler<DeleteEmployeeJobCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeJobCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteEmployeeJobCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.EmployeeJobRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.EmployeeJobNotFound);

        _unitOfWork.EmployeeJobRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.EmployeeJobNotDeleted);
    }
}
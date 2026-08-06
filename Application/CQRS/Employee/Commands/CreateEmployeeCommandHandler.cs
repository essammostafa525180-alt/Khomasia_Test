using Application.Abstractions;

namespace Application.CQRS.Employee.Commands;

public class CreateEmployeeCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? EmployeeJobFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.UserAggregate.Employee.Create(request.Code, request.Name, request.NameAr, request.EmployeeJobFk, request.IsActive);

        await _unitOfWork.EmployeeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.EmployeeNotInserted);
    }
}
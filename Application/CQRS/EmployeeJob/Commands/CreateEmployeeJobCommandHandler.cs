using Application.Abstractions;

namespace Application.CQRS.EmployeeJob.Commands;

public class CreateEmployeeJobCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? EmployeeJobFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateEmployeeJobCommandHandler : ICommandHandler<CreateEmployeeJobCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeJobCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateEmployeeJobCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.EmployeeJob.Create(request.Code, request.Name, request.NameAr, request.EmployeeJobFk, request.IsActive);

        await _unitOfWork.EmployeeJobRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.EmployeeJobNotInserted);
    }
}
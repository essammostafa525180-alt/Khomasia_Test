using Application.Abstractions;

namespace Application.CQRS.EmployeeJob.Commands;

public class UpdateEmployeeJobCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? EmployeeJobFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateEmployeeJobCommandHandler : ICommandHandler<UpdateEmployeeJobCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmployeeJobCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateEmployeeJobCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.EmployeeJobRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.EmployeeJobNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.EmployeeJobFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.EmployeeJobNotUpdated);
    }
}
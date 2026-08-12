using Application.Abstractions;

namespace Application.CQRS.Project.Commands;

public class CreateProjectCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? CompanyFk { get; set; }
        public int? StoreFk { get; set; }
        public int? CustomerFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.CompanyAggregate.Project.Create(request.Code, request.Name, request.NameAr, request.CompanyFk, request.StoreFk, request.CustomerFk, request.IsActive);

        await _unitOfWork.ProjectRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ProjectNotInserted);
    }
}
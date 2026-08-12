using Application.Abstractions;

namespace Application.CQRS.Project.Commands;

public class UpdateProjectCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? CompanyFk { get; set; }
        public int? StoreFk { get; set; }
        public int? CustomerFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateProjectCommandHandler : ICommandHandler<UpdateProjectCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ProjectRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ProjectNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.CompanyFk, request.StoreFk, request.CustomerFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ProjectNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.AssignSiteSection.Commands;

public class UpdateAssignSiteSectionCommand : ICommand<Result>
{
        public int Id { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssignSiteSectionCommandHandler : ICommandHandler<UpdateAssignSiteSectionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssignSiteSectionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssignSiteSectionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssignSiteSectionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssignSiteSectionNotFound);

        entity.Update(request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssignSiteSectionNotUpdated);
    }
}
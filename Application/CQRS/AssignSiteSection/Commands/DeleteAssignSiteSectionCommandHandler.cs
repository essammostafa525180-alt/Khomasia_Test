using Application.Abstractions;

namespace Application.CQRS.AssignSiteSection.Commands;

public class DeleteAssignSiteSectionCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssignSiteSectionCommandHandler : ICommandHandler<DeleteAssignSiteSectionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssignSiteSectionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssignSiteSectionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssignSiteSectionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssignSiteSectionNotFound);

        _unitOfWork.AssignSiteSectionRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssignSiteSectionNotDeleted);
    }
}
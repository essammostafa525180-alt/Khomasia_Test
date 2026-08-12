using Application.Abstractions;

namespace Application.CQRS.AssignSiteSection.Commands;

public class CreateAssignSiteSectionCommand : ICommand<Result<int>>
{
        public bool IsActive { get; set; }
}
internal class CreateAssignSiteSectionCommandHandler : ICommandHandler<CreateAssignSiteSectionCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssignSiteSectionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssignSiteSectionCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SiteAggregate.AssignSiteSection.Create(request.IsActive);

        await _unitOfWork.AssignSiteSectionRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssignSiteSectionNotInserted);
    }
}
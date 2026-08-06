using Application.Abstractions;

namespace Application.CQRS.Section.Commands;

public class DeleteSectionCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSectionCommandHandler : ICommandHandler<DeleteSectionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSectionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SectionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SectionNotFound);

        _unitOfWork.SectionRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SectionNotDeleted);
    }
}
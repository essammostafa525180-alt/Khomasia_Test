using Application.Abstractions;

namespace Application.CQRS.SubSection.Commands;

public class DeleteSubSectionCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSubSectionCommandHandler : ICommandHandler<DeleteSubSectionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSubSectionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSubSectionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SubSectionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SubSectionNotFound);

        _unitOfWork.SubSectionRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SubSectionNotDeleted);
    }
}
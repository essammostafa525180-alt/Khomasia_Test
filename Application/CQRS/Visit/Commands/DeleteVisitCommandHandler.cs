using Application.Abstractions;

namespace Application.CQRS.Visit.Commands;

public class DeleteVisitCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVisitCommandHandler : ICommandHandler<DeleteVisitCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVisitCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVisitCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VisitRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VisitNotFound);

        _unitOfWork.VisitRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VisitNotDeleted);
    }
}
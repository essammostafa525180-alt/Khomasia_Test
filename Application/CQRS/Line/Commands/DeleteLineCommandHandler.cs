using Application.Abstractions;

namespace Application.CQRS.Line.Commands;

public class DeleteLineCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteLineCommandHandler : ICommandHandler<DeleteLineCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLineCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteLineCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.LineRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.LineNotFound);

        _unitOfWork.LineRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.LineNotDeleted);
    }
}
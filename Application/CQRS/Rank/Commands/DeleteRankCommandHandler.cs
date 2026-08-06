using Application.Abstractions;

namespace Application.CQRS.Rank.Commands;

public class DeleteRankCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteRankCommandHandler : ICommandHandler<DeleteRankCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRankCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteRankCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RankRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RankNotFound);

        _unitOfWork.RankRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RankNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.ItemBalanceStatus.Commands;

public class DeleteItemBalanceStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteItemBalanceStatusCommandHandler : ICommandHandler<DeleteItemBalanceStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteItemBalanceStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteItemBalanceStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ItemBalanceStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ItemBalanceStatusNotFound);

        _unitOfWork.ItemBalanceStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ItemBalanceStatusNotDeleted);
    }
}
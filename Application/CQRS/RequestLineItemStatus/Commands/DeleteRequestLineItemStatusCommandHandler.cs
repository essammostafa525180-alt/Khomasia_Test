using Application.Abstractions;

namespace Application.CQRS.RequestLineItemStatus.Commands;

public class DeleteRequestLineItemStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteRequestLineItemStatusCommandHandler : ICommandHandler<DeleteRequestLineItemStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRequestLineItemStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteRequestLineItemStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RequestLineItemStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RequestLineItemStatusNotFound);

        _unitOfWork.RequestLineItemStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RequestLineItemStatusNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.ItemRequestStatus.Commands;

public class DeleteItemRequestStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteItemRequestStatusCommandHandler : ICommandHandler<DeleteItemRequestStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteItemRequestStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteItemRequestStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ItemRequestStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ItemRequestStatusNotFound);

        _unitOfWork.ItemRequestStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ItemRequestStatusNotDeleted);
    }
}
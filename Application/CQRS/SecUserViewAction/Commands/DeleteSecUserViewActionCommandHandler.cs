using Application.Abstractions;

namespace Application.CQRS.SecUserViewAction.Commands;

public class DeleteSecUserViewActionCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecUserViewActionCommandHandler : ICommandHandler<DeleteSecUserViewActionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecUserViewActionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecUserViewActionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecUserViewActionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecUserViewActionNotFound);

        _unitOfWork.SecUserViewActionRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecUserViewActionNotDeleted);
    }
}
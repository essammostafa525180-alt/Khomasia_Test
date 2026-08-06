using Application.Abstractions;

namespace Application.CQRS.SecUserSecurableValue.Commands;

public class DeleteSecUserSecurableValueCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecUserSecurableValueCommandHandler : ICommandHandler<DeleteSecUserSecurableValueCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecUserSecurableValueCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecUserSecurableValueCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecUserSecurableValueRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecUserSecurableValueNotFound);

        _unitOfWork.SecUserSecurableValueRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecUserSecurableValueNotDeleted);
    }
}
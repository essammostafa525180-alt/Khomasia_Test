using Application.Abstractions;

namespace Application.CQRS.SecUserProperty.Commands;

public class DeleteSecUserPropertyCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecUserPropertyCommandHandler : ICommandHandler<DeleteSecUserPropertyCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecUserPropertyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecUserPropertyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecUserPropertyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecUserPropertyNotFound);

        _unitOfWork.SecUserPropertyRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecUserPropertyNotDeleted);
    }
}
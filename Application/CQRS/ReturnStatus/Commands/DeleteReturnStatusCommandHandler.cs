using Application.Abstractions;

namespace Application.CQRS.ReturnStatus.Commands;

public class DeleteReturnStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteReturnStatusCommandHandler : ICommandHandler<DeleteReturnStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReturnStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteReturnStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ReturnStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ReturnStatusNotFound);

        _unitOfWork.ReturnStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ReturnStatusNotDeleted);
    }
}
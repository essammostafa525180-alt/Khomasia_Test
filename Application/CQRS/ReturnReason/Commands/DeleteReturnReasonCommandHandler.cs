using Application.Abstractions;

namespace Application.CQRS.ReturnReason.Commands;

public class DeleteReturnReasonCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteReturnReasonCommandHandler : ICommandHandler<DeleteReturnReasonCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReturnReasonCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteReturnReasonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ReturnReasonRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ReturnReasonNotFound);

        _unitOfWork.ReturnReasonRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ReturnReasonNotDeleted);
    }
}
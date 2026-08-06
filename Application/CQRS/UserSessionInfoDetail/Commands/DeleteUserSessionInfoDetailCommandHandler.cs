using Application.Abstractions;

namespace Application.CQRS.UserSessionInfoDetail.Commands;

public class DeleteUserSessionInfoDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteUserSessionInfoDetailCommandHandler : ICommandHandler<DeleteUserSessionInfoDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserSessionInfoDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteUserSessionInfoDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.UserSessionInfoDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.UserSessionInfoDetailNotFound);

        _unitOfWork.UserSessionInfoDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.UserSessionInfoDetailNotDeleted);
    }
}
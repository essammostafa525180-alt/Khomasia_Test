using Application.Abstractions;

namespace Application.CQRS.UserSessionInfo.Commands;

public class DeleteUserSessionInfoCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteUserSessionInfoCommandHandler : ICommandHandler<DeleteUserSessionInfoCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserSessionInfoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteUserSessionInfoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.UserSessionInfoRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.UserSessionInfoNotFound);

        _unitOfWork.UserSessionInfoRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.UserSessionInfoNotDeleted);
    }
}
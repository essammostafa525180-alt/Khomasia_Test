using Application.Abstractions;

namespace Application.CQRS.AdUser.Commands;

public class DeleteAdUserCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAdUserCommandHandler : ICommandHandler<DeleteAdUserCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAdUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAdUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AdUserRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AdUserNotFound);

        _unitOfWork.AdUserRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AdUserNotDeleted);
    }
}
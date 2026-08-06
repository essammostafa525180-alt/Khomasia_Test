using Application.Abstractions;

namespace Application.CQRS.AdUser.Commands;

public class UpdateAdUserCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? AdAccount { get; set; }
        public string? Mail { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAdUserCommandHandler : ICommandHandler<UpdateAdUserCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAdUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAdUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AdUserRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AdUserNotFound);

        entity.Update(request.AdAccount, request.Mail, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AdUserNotUpdated);
    }
}
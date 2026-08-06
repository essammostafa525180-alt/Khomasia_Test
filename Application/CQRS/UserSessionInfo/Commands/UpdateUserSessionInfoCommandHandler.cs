using Application.Abstractions;

namespace Application.CQRS.UserSessionInfo.Commands;

public class UpdateUserSessionInfoCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LastHit { get; set; }
        public DateTime ExpireAt { get; set; }
        public bool? RemeberMe { get; set; }
        public string? Language { get; set; }
        public string? ValidModules { get; set; }
        public Guid UserToken { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateUserSessionInfoCommandHandler : ICommandHandler<UpdateUserSessionInfoCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserSessionInfoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateUserSessionInfoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.UserSessionInfoRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.UserSessionInfoNotFound);

        entity.Update(request.UserId, request.LastHit, request.ExpireAt, request.RemeberMe, request.Language, request.ValidModules, request.UserToken, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.UserSessionInfoNotUpdated);
    }
}
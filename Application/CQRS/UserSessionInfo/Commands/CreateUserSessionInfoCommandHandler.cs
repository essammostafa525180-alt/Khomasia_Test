using Application.Abstractions;

namespace Application.CQRS.UserSessionInfo.Commands;

public class CreateUserSessionInfoCommand : ICommand<Result<int>>
{
        public int UserId { get; set; }
        public DateTime LastHit { get; set; }
        public DateTime ExpireAt { get; set; }
        public bool? RemeberMe { get; set; }
        public string? Language { get; set; }
        public string? ValidModules { get; set; }
        public Guid UserToken { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateUserSessionInfoCommandHandler : ICommandHandler<CreateUserSessionInfoCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserSessionInfoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateUserSessionInfoCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.UserAggregate.UserSessionInfo.Create(request.UserId, request.LastHit, request.ExpireAt, request.RemeberMe, request.Language, request.ValidModules, request.UserToken, request.IsActive);

        await _unitOfWork.UserSessionInfoRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.UserSessionInfoNotInserted);
    }
}
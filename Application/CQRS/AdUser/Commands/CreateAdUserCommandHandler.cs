using Application.Abstractions;

namespace Application.CQRS.AdUser.Commands;

public class CreateAdUserCommand : ICommand<Result<int>>
{
        public string? AdAccount { get; set; }
        public string? Mail { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAdUserCommandHandler : ICommandHandler<CreateAdUserCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAdUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAdUserCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.UserAggregate.AdUser.Create(request.AdAccount, request.Mail, request.IsActive);

        await _unitOfWork.AdUserRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AdUserNotInserted);
    }
}
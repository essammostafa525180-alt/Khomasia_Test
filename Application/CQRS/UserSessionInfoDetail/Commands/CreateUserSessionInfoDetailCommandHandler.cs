using Application.Abstractions;

namespace Application.CQRS.UserSessionInfoDetail.Commands;

public class CreateUserSessionInfoDetailCommand : ICommand<Result<int>>
{
        public int? UserSessionInfoId { get; set; }
        public int? InfoKey { get; set; }
        public string? InfoValue { get; set; }
        public string? InfoDescription { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateUserSessionInfoDetailCommandHandler : ICommandHandler<CreateUserSessionInfoDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserSessionInfoDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateUserSessionInfoDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.UserAggregate.UserSessionInfoDetail.Create(request.UserSessionInfoId, request.InfoKey, request.InfoValue, request.InfoDescription, request.IsActive);

        await _unitOfWork.UserSessionInfoDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.UserSessionInfoDetailNotInserted);
    }
}
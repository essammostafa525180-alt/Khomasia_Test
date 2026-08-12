using Application.Abstractions;

namespace Application.CQRS.SecUserModule.Commands;

public class CreateSecUserModuleCommand : ICommand<Result<int>>
{
        public int UserId { get; set; }
        public int SecModuleId { get; set; }
        public bool? IsAllowed { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecUserModuleCommandHandler : ICommandHandler<CreateSecUserModuleCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecUserModuleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecUserModuleCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SecurityAggregate.SecUserModule.Create(request.UserId, request.SecModuleId, request.IsAllowed, request.IsActive);

        await _unitOfWork.SecUserModuleRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecUserModuleNotInserted);
    }
}
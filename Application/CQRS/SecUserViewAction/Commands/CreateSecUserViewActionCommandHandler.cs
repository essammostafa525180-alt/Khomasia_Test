using Application.Abstractions;

namespace Application.CQRS.SecUserViewAction.Commands;

public class CreateSecUserViewActionCommand : ICommand<Result<int>>
{
        public int UserId { get; set; }
        public int ViewActionId { get; set; }
        public bool? IsAllow { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecUserViewActionCommandHandler : ICommandHandler<CreateSecUserViewActionCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecUserViewActionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecUserViewActionCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SecurityAggregate.SecUserViewAction.Create(request.UserId, request.ViewActionId, request.IsAllow, request.IsActive);

        await _unitOfWork.SecUserViewActionRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecUserViewActionNotInserted);
    }
}
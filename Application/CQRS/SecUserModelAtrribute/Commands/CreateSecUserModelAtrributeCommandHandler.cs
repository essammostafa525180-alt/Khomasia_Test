using Application.Abstractions;

namespace Application.CQRS.SecUserModelAtrribute.Commands;

public class CreateSecUserModelAtrributeCommand : ICommand<Result<int>>
{
        public int UserId { get; set; }
        public int ModelAttributeId { get; set; }
        public int? Mode { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecUserModelAtrributeCommandHandler : ICommandHandler<CreateSecUserModelAtrributeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecUserModelAtrributeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecUserModelAtrributeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SecurityAggregate.SecUserModelAtrribute.Create(request.UserId, request.ModelAttributeId, request.Mode, request.IsActive);

        await _unitOfWork.SecUserModelAtrributeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecUserModelAtrributeNotInserted);
    }
}
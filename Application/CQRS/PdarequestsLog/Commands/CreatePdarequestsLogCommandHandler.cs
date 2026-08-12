using Application.Abstractions;

namespace Application.CQRS.PdarequestsLog.Commands;

public class CreatePdarequestsLogCommand : ICommand<Result<int>>
{
        public int? RequestFk { get; set; }
        public int? AssignedToFk { get; set; }
        public bool? IsChanged { get; set; }
        public string? PdarequestType { get; set; }
        public bool IsActive { get; set; }
}
internal class CreatePdarequestsLogCommandHandler : ICommandHandler<CreatePdarequestsLogCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePdarequestsLogCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreatePdarequestsLogCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.PdaAggregate.PdarequestsLog.Create(request.RequestFk, request.AssignedToFk, request.IsChanged, request.PdarequestType, request.IsActive);

        await _unitOfWork.PdarequestsLogRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.PdarequestsLogNotInserted);
    }
}
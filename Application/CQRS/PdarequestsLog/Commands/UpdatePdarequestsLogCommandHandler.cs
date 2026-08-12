using Application.Abstractions;

namespace Application.CQRS.PdarequestsLog.Commands;

public class UpdatePdarequestsLogCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? RequestFk { get; set; }
        public int? AssignedToFk { get; set; }
        public bool? IsChanged { get; set; }
        public string? PdarequestType { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdatePdarequestsLogCommandHandler : ICommandHandler<UpdatePdarequestsLogCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePdarequestsLogCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePdarequestsLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PdarequestsLogRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PdarequestsLogNotFound);

        entity.Update(request.RequestFk, request.AssignedToFk, request.IsChanged, request.PdarequestType, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PdarequestsLogNotUpdated);
    }
}
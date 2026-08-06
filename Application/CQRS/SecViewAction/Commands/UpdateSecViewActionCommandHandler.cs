using Application.Abstractions;

namespace Application.CQRS.SecViewAction.Commands;

public class UpdateSecViewActionCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int ViewActionId { get; set; }
        public int? ViewId { get; set; }
        public string? Action { get; set; }
        public string? ActionNameAr { get; set; }
        public string? ActionName { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecViewActionCommandHandler : ICommandHandler<UpdateSecViewActionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecViewActionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecViewActionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecViewActionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecViewActionNotFound);

        entity.Update(request.ViewActionId, request.ViewId, request.Action, request.ActionNameAr, request.ActionName, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecViewActionNotUpdated);
    }
}
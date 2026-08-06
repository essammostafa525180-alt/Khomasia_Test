using Application.Abstractions;

namespace Application.CQRS.SecView.Commands;

public class UpdateSecViewCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int ViewId { get; set; }
        public string? ViewName { get; set; }
        public string? ViewDisplayName { get; set; }
        public bool? IsVisibleToMenu { get; set; }
        public string? Url { get; set; }
        public int? SecModuleId { get; set; }
        public string? ViewDisplayNameAr { get; set; }
        public int? ParentId { get; set; }
        public int? Sequence { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecViewCommandHandler : ICommandHandler<UpdateSecViewCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecViewCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecViewCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecViewRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecViewNotFound);

        entity.Update(request.ViewId, request.ViewName, request.ViewDisplayName, request.IsVisibleToMenu, request.Url, request.SecModuleId, request.ViewDisplayNameAr, request.ParentId, request.Sequence, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecViewNotUpdated);
    }
}
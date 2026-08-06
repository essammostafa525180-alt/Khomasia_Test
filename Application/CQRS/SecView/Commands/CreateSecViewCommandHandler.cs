using Application.Abstractions;

namespace Application.CQRS.SecView.Commands;

public class CreateSecViewCommand : ICommand<Result<int>>
{
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
internal class CreateSecViewCommandHandler : ICommandHandler<CreateSecViewCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecViewCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecViewCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SecurityAggregate.SecView.Create(request.ViewId, request.ViewName, request.ViewDisplayName, request.IsVisibleToMenu, request.Url, request.SecModuleId, request.ViewDisplayNameAr, request.ParentId, request.Sequence, request.IsActive);

        await _unitOfWork.SecViewRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecViewNotInserted);
    }
}
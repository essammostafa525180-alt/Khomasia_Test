using Application.Abstractions;

namespace Application.CQRS.SecViewAction.Commands;

public class CreateSecViewActionCommand : ICommand<Result<int>>
{
        public int ViewActionId { get; set; }
        public int? ViewId { get; set; }
        public string? Action { get; set; }
        public string? ActionNameAr { get; set; }
        public string? ActionName { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecViewActionCommandHandler : ICommandHandler<CreateSecViewActionCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecViewActionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecViewActionCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.SecViewAction.Create(request.ViewActionId, request.ViewId, request.Action, request.ActionNameAr, request.ActionName, request.IsActive);

        await _unitOfWork.SecViewActionRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecViewActionNotInserted);
    }
}
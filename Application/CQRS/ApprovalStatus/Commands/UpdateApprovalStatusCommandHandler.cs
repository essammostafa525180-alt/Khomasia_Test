using Application.Abstractions;

namespace Application.CQRS.ApprovalStatus.Commands;

public class UpdateApprovalStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateApprovalStatusCommandHandler : ICommandHandler<UpdateApprovalStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateApprovalStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateApprovalStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ApprovalStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ApprovalStatusNotUpdated);
    }
}
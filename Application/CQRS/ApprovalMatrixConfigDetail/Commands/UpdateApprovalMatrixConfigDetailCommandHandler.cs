using Application.Abstractions;

namespace Application.CQRS.ApprovalMatrixConfigDetail.Commands;

public class UpdateApprovalMatrixConfigDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? ApprovalMatrixConfigFk { get; set; }
        public int? ApprovalMatrixRangeFk { get; set; }
        public int StepNo { get; set; }
        public string? StepName { get; set; }
        public string? StepNameAr { get; set; }
        public int? UserFk { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateApprovalMatrixConfigDetailCommandHandler : ICommandHandler<UpdateApprovalMatrixConfigDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateApprovalMatrixConfigDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateApprovalMatrixConfigDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalMatrixConfigDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ApprovalMatrixConfigDetailNotFound);

        entity.Update(request.ApprovalMatrixConfigFk, request.ApprovalMatrixRangeFk, request.StepNo, request.StepName, request.StepNameAr, request.UserFk, request.Email, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ApprovalMatrixConfigDetailNotUpdated);
    }
}
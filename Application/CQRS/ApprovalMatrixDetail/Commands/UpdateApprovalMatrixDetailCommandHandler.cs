using Application.Abstractions;

namespace Application.CQRS.ApprovalMatrixDetail.Commands;

public class UpdateApprovalMatrixDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? ApprovalMatrixFk { get; set; }
        public int? ApprovalMatrixConfigDetailFk { get; set; }
        public int ApprovalStatusFk { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? UserFk { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateApprovalMatrixDetailCommandHandler : ICommandHandler<UpdateApprovalMatrixDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateApprovalMatrixDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateApprovalMatrixDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalMatrixDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ApprovalMatrixDetailNotFound);

        entity.Update(request.ApprovalMatrixFk, request.ApprovalMatrixConfigDetailFk, request.ApprovalStatusFk, request.ApprovalDate, request.UserFk, request.Email, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ApprovalMatrixDetailNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.ApprovalMatrix.Commands;

public class UpdateApprovalMatrixCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? ScreenFk { get; set; }
        public int? EntityId { get; set; }
        public int? ApprovalMatrixConfigFk { get; set; }
        public int ApprovalStatusFk { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateApprovalMatrixCommandHandler : ICommandHandler<UpdateApprovalMatrixCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateApprovalMatrixCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateApprovalMatrixCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalMatrixRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ApprovalMatrixNotFound);

        entity.Update(request.ScreenFk, request.EntityId, request.ApprovalMatrixConfigFk, request.ApprovalStatusFk, request.ApprovalDate, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ApprovalMatrixNotUpdated);
    }
}
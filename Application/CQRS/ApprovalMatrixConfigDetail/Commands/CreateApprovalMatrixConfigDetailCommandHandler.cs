using Application.Abstractions;

namespace Application.CQRS.ApprovalMatrixConfigDetail.Commands;

public class CreateApprovalMatrixConfigDetailCommand : ICommand<Result<int>>
{
        public int? ApprovalMatrixConfigFk { get; set; }
        public int? ApprovalMatrixRangeFk { get; set; }
        public int StepNo { get; set; }
        public string? StepName { get; set; }
        public string? StepNameAr { get; set; }
        public int? UserFk { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateApprovalMatrixConfigDetailCommandHandler : ICommandHandler<CreateApprovalMatrixConfigDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateApprovalMatrixConfigDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateApprovalMatrixConfigDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.ApprovalMatrixConfigDetail.Create(request.ApprovalMatrixConfigFk, request.ApprovalMatrixRangeFk, request.StepNo, request.StepName, request.StepNameAr, request.UserFk, request.Email, request.IsActive);

        await _unitOfWork.ApprovalMatrixConfigDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ApprovalMatrixConfigDetailNotInserted);
    }
}
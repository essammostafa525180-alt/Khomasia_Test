using Application.Abstractions;

namespace Application.CQRS.ApprovalMatrixDetail.Commands;

public class CreateApprovalMatrixDetailCommand : ICommand<Result<int>>
{
        public int? ApprovalMatrixFk { get; set; }
        public int? ApprovalMatrixConfigDetailFk { get; set; }
        public int ApprovalStatusFk { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? UserFk { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateApprovalMatrixDetailCommandHandler : ICommandHandler<CreateApprovalMatrixDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateApprovalMatrixDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateApprovalMatrixDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.ApprovalMatrixDetail.Create(request.ApprovalMatrixFk, request.ApprovalMatrixConfigDetailFk, request.ApprovalStatusFk, request.ApprovalDate, request.UserFk, request.Email, request.IsActive);

        await _unitOfWork.ApprovalMatrixDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ApprovalMatrixDetailNotInserted);
    }
}
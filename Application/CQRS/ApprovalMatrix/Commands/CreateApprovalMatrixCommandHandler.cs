using Application.Abstractions;

namespace Application.CQRS.ApprovalMatrix.Commands;

public class CreateApprovalMatrixCommand : ICommand<Result<int>>
{
        public int? ScreenFk { get; set; }
        public int? EntityId { get; set; }
        public int? ApprovalMatrixConfigFk { get; set; }
        public int ApprovalStatusFk { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateApprovalMatrixCommandHandler : ICommandHandler<CreateApprovalMatrixCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateApprovalMatrixCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateApprovalMatrixCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.ApprovalMatrix.Create(request.ScreenFk, request.EntityId, request.ApprovalMatrixConfigFk, request.ApprovalStatusFk, request.ApprovalDate, request.IsActive);

        await _unitOfWork.ApprovalMatrixRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ApprovalMatrixNotInserted);
    }
}
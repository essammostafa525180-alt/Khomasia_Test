using Application.Abstractions;

namespace Application.CQRS.ApprovalMatrixRange.Commands;

public class CreateApprovalMatrixRangeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public decimal? RangeFrom { get; set; }
        public decimal? RangeTo { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateApprovalMatrixRangeCommandHandler : ICommandHandler<CreateApprovalMatrixRangeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateApprovalMatrixRangeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateApprovalMatrixRangeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.ApprovalMatrixRange.Create(request.Name, request.RangeFrom, request.RangeTo, request.IsActive);

        await _unitOfWork.ApprovalMatrixRangeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ApprovalMatrixRangeNotInserted);
    }
}
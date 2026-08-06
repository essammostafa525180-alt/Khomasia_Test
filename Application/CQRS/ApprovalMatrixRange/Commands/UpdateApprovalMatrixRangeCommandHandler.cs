using Application.Abstractions;

namespace Application.CQRS.ApprovalMatrixRange.Commands;

public class UpdateApprovalMatrixRangeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? RangeFrom { get; set; }
        public decimal? RangeTo { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateApprovalMatrixRangeCommandHandler : ICommandHandler<UpdateApprovalMatrixRangeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateApprovalMatrixRangeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateApprovalMatrixRangeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalMatrixRangeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ApprovalMatrixRangeNotFound);

        entity.Update(request.Name, request.RangeFrom, request.RangeTo, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ApprovalMatrixRangeNotUpdated);
    }
}
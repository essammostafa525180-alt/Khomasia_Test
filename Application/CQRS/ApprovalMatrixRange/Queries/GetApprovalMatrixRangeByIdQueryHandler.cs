using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ApprovalMatrixRange.Queries;

public class GetApprovalMatrixRangeByIdQuery : IQuery<Result<ApprovalMatrixRangeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetApprovalMatrixRangeByIdQueryHandler : IQueryHandler<GetApprovalMatrixRangeByIdQuery, Result<ApprovalMatrixRangeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetApprovalMatrixRangeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ApprovalMatrixRangeDetailsResponse>> Handle(GetApprovalMatrixRangeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalMatrixRangeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ApprovalMatrixRangeDetailsResponse>.Failure(Errors.ApprovalMatrixRangeNotFound);

        var response = entity.Adapt<ApprovalMatrixRangeDetailsResponse>();

        return Result<ApprovalMatrixRangeDetailsResponse>.Success(response);
    }
}
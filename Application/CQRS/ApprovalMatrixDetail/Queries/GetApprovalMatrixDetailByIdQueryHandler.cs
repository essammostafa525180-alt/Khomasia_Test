using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ApprovalMatrixDetail.Queries;

public class GetApprovalMatrixDetailByIdQuery : IQuery<Result<ApprovalMatrixDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetApprovalMatrixDetailByIdQueryHandler : IQueryHandler<GetApprovalMatrixDetailByIdQuery, Result<ApprovalMatrixDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetApprovalMatrixDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ApprovalMatrixDetailDetailsResponse>> Handle(GetApprovalMatrixDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalMatrixDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ApprovalMatrixDetailDetailsResponse>.Failure(Errors.ApprovalMatrixDetailNotFound);

        var response = entity.Adapt<ApprovalMatrixDetailDetailsResponse>();

        return Result<ApprovalMatrixDetailDetailsResponse>.Success(response);
    }
}
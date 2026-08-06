using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ApprovalMatrixConfigDetail.Queries;

public class GetApprovalMatrixConfigDetailByIdQuery : IQuery<Result<ApprovalMatrixConfigDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetApprovalMatrixConfigDetailByIdQueryHandler : IQueryHandler<GetApprovalMatrixConfigDetailByIdQuery, Result<ApprovalMatrixConfigDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetApprovalMatrixConfigDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ApprovalMatrixConfigDetailDetailsResponse>> Handle(GetApprovalMatrixConfigDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalMatrixConfigDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ApprovalMatrixConfigDetailDetailsResponse>.Failure(Errors.ApprovalMatrixConfigDetailNotFound);

        var response = entity.Adapt<ApprovalMatrixConfigDetailDetailsResponse>();

        return Result<ApprovalMatrixConfigDetailDetailsResponse>.Success(response);
    }
}
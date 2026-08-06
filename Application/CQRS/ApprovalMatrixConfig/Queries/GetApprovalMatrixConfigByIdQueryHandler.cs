using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ApprovalMatrixConfig.Queries;

public class GetApprovalMatrixConfigByIdQuery : IQuery<Result<ApprovalMatrixConfigDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetApprovalMatrixConfigByIdQueryHandler : IQueryHandler<GetApprovalMatrixConfigByIdQuery, Result<ApprovalMatrixConfigDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetApprovalMatrixConfigByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ApprovalMatrixConfigDetailsResponse>> Handle(GetApprovalMatrixConfigByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalMatrixConfigRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ApprovalMatrixConfigDetailsResponse>.Failure(Errors.ApprovalMatrixConfigNotFound);

        var response = entity.Adapt<ApprovalMatrixConfigDetailsResponse>();

        return Result<ApprovalMatrixConfigDetailsResponse>.Success(response);
    }
}
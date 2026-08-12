using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ApprovalMatrix.Queries;

public class GetApprovalMatrixByIdQuery : IQuery<Result<ApprovalMatrixDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetApprovalMatrixByIdQueryHandler : IQueryHandler<GetApprovalMatrixByIdQuery, Result<ApprovalMatrixDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetApprovalMatrixByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ApprovalMatrixDetailsResponse>> Handle(GetApprovalMatrixByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalMatrixRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ApprovalMatrixDetailsResponse>.Failure(Errors.ApprovalMatrixNotFound);

        var response = entity.Adapt<ApprovalMatrixDetailsResponse>();

        return Result<ApprovalMatrixDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ApprovalStatus.Queries;

public class GetApprovalStatusByIdQuery : IQuery<Result<ApprovalStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetApprovalStatusByIdQueryHandler : IQueryHandler<GetApprovalStatusByIdQuery, Result<ApprovalStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetApprovalStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ApprovalStatusDetailsResponse>> Handle(GetApprovalStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ApprovalStatusDetailsResponse>.Failure(Errors.ApprovalStatusNotFound);

        var response = entity.Adapt<ApprovalStatusDetailsResponse>();

        return Result<ApprovalStatusDetailsResponse>.Success(response);
    }
}
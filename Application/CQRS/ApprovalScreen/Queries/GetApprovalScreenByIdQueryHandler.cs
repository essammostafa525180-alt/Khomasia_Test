using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ApprovalScreen.Queries;

public class GetApprovalScreenByIdQuery : IQuery<Result<ApprovalScreenDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetApprovalScreenByIdQueryHandler : IQueryHandler<GetApprovalScreenByIdQuery, Result<ApprovalScreenDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetApprovalScreenByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ApprovalScreenDetailsResponse>> Handle(GetApprovalScreenByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalScreenRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ApprovalScreenDetailsResponse>.Failure(Errors.ApprovalScreenNotFound);

        var response = entity.Adapt<ApprovalScreenDetailsResponse>();

        return Result<ApprovalScreenDetailsResponse>.Success(response);
    }
}
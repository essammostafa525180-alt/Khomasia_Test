using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetCountIssue.Queries;

public class GetAssetCountIssueByIdQuery : IQuery<Result<AssetCountIssueDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetCountIssueByIdQueryHandler : IQueryHandler<GetAssetCountIssueByIdQuery, Result<AssetCountIssueDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetCountIssueByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetCountIssueDetailsResponse>> Handle(GetAssetCountIssueByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountIssueRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetCountIssueDetailsResponse>.Failure(Errors.AssetCountIssueNotFound);

        var response = entity.Adapt<AssetCountIssueDetailsResponse>();

        return Result<AssetCountIssueDetailsResponse>.Success(response);
    }
}
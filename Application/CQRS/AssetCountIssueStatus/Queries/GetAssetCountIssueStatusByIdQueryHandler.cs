using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetCountIssueStatus.Queries;

public class GetAssetCountIssueStatusByIdQuery : IQuery<Result<AssetCountIssueStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetCountIssueStatusByIdQueryHandler : IQueryHandler<GetAssetCountIssueStatusByIdQuery, Result<AssetCountIssueStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetCountIssueStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetCountIssueStatusDetailsResponse>> Handle(GetAssetCountIssueStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountIssueStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetCountIssueStatusDetailsResponse>.Failure(Errors.AssetCountIssueStatusNotFound);

        var response = entity.Adapt<AssetCountIssueStatusDetailsResponse>();

        return Result<AssetCountIssueStatusDetailsResponse>.Success(response);
    }
}
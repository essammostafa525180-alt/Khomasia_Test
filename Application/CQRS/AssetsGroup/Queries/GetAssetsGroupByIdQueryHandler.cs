using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetsGroup.Queries;

public class GetAssetsGroupByIdQuery : IQuery<Result<AssetsGroupDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetsGroupByIdQueryHandler : IQueryHandler<GetAssetsGroupByIdQuery, Result<AssetsGroupDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetsGroupByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetsGroupDetailsResponse>> Handle(GetAssetsGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetsGroupRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetsGroupDetailsResponse>.Failure(Errors.AssetsGroupNotFound);

        var response = entity.Adapt<AssetsGroupDetailsResponse>();

        return Result<AssetsGroupDetailsResponse>.Success(response);
    }
}
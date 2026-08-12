using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetsType.Queries;

public class GetAssetsTypeByIdQuery : IQuery<Result<AssetsTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetsTypeByIdQueryHandler : IQueryHandler<GetAssetsTypeByIdQuery, Result<AssetsTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetsTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetsTypeDetailsResponse>> Handle(GetAssetsTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetsTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetsTypeDetailsResponse>.Failure(Errors.AssetsTypeNotFound);

        var response = entity.Adapt<AssetsTypeDetailsResponse>();

        return Result<AssetsTypeDetailsResponse>.Success(response);
    }
}
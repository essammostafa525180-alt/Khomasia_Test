using Application.Abstractions;
using Mapster;

namespace Application.CQRS.StorageUnit.Queries;

public class GetStorageUnitByIdQuery : IQuery<Result<StorageUnitDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetStorageUnitByIdQueryHandler : IQueryHandler<GetStorageUnitByIdQuery, Result<StorageUnitDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetStorageUnitByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<StorageUnitDetailsResponse>> Handle(GetStorageUnitByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StorageUnitRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<StorageUnitDetailsResponse>.Failure(Errors.StorageUnitNotFound);

        var response = entity.Adapt<StorageUnitDetailsResponse>();

        return Result<StorageUnitDetailsResponse>.Success(response);
    }
}

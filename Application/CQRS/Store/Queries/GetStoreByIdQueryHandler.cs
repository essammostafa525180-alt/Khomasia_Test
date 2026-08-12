using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Store.Queries;

public class GetStoreByIdQuery : IQuery<Result<StoreDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetStoreByIdQueryHandler : IQueryHandler<GetStoreByIdQuery, Result<StoreDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetStoreByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<StoreDetailsResponse>> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StoreRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<StoreDetailsResponse>.Failure(Errors.StoreNotFound);

        var response = entity.Adapt<StoreDetailsResponse>();

        return Result<StoreDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.StoreKeeper.Queries;

public class GetStoreKeeperByIdQuery : IQuery<Result<StoreKeeperDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetStoreKeeperByIdQueryHandler : IQueryHandler<GetStoreKeeperByIdQuery, Result<StoreKeeperDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetStoreKeeperByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<StoreKeeperDetailsResponse>> Handle(GetStoreKeeperByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StoreKeeperRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<StoreKeeperDetailsResponse>.Failure(Errors.StoreKeeperNotFound);

        var response = entity.Adapt<StoreKeeperDetailsResponse>();

        return Result<StoreKeeperDetailsResponse>.Success(response);
    }
}
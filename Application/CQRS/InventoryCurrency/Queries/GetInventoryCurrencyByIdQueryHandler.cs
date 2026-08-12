using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryCurrency.Queries;

public class GetInventoryCurrencyByIdQuery : IQuery<Result<InventoryCurrencyDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryCurrencyByIdQueryHandler : IQueryHandler<GetInventoryCurrencyByIdQuery, Result<InventoryCurrencyDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryCurrencyByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryCurrencyDetailsResponse>> Handle(GetInventoryCurrencyByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryCurrencyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryCurrencyDetailsResponse>.Failure(Errors.InventoryCurrencyNotFound);

        var response = entity.Adapt<InventoryCurrencyDetailsResponse>();

        return Result<InventoryCurrencyDetailsResponse>.Success(response);
    }
}
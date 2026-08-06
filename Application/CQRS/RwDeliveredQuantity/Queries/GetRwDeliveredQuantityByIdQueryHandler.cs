using Application.Abstractions;
using Mapster;

namespace Application.CQRS.RwDeliveredQuantity.Queries;

public class GetRwDeliveredQuantityByIdQuery : IQuery<Result<RwDeliveredQuantityDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetRwDeliveredQuantityByIdQueryHandler : IQueryHandler<GetRwDeliveredQuantityByIdQuery, Result<RwDeliveredQuantityDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRwDeliveredQuantityByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<RwDeliveredQuantityDetailsResponse>> Handle(GetRwDeliveredQuantityByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwDeliveredQuantityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<RwDeliveredQuantityDetailsResponse>.Failure(Errors.RwDeliveredQuantityNotFound);

        var response = entity.Adapt<RwDeliveredQuantityDetailsResponse>();

        return Result<RwDeliveredQuantityDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Warehouse.Queries;

public class GetWarehouseByIdQuery : IQuery<Result<WarehouseDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetWarehouseByIdQueryHandler : IQueryHandler<GetWarehouseByIdQuery, Result<WarehouseDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetWarehouseByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<WarehouseDetailsResponse>> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WarehouseRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<WarehouseDetailsResponse>.Failure(Errors.WarehouseNotFound);

        var response = entity.Adapt<WarehouseDetailsResponse>();

        return Result<WarehouseDetailsResponse>.Success(response);
    }
}

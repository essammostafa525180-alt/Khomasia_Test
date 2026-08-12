using Application.Abstractions;
using Mapster;

namespace Application.CQRS.WarehouseType.Queries;

public class GetWarehouseTypeByIdQuery : IQuery<Result<WarehouseTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetWarehouseTypeByIdQueryHandler : IQueryHandler<GetWarehouseTypeByIdQuery, Result<WarehouseTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetWarehouseTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<WarehouseTypeDetailsResponse>> Handle(GetWarehouseTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WarehouseTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<WarehouseTypeDetailsResponse>.Failure(Errors.WarehouseTypeNotFound);

        var response = entity.Adapt<WarehouseTypeDetailsResponse>();

        return Result<WarehouseTypeDetailsResponse>.Success(response);
    }
}

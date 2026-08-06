using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemVendor.Queries;

public class GetInventoryItemVendorByIdQuery : IQuery<Result<InventoryItemVendorDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemVendorByIdQueryHandler : IQueryHandler<GetInventoryItemVendorByIdQuery, Result<InventoryItemVendorDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemVendorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemVendorDetailsResponse>> Handle(GetInventoryItemVendorByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemVendorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemVendorDetailsResponse>.Failure(Errors.InventoryItemVendorNotFound);

        var response = entity.Adapt<InventoryItemVendorDetailsResponse>();

        return Result<InventoryItemVendorDetailsResponse>.Success(response);
    }
}
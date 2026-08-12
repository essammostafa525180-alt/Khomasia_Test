using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderVendorSelection.Queries;

public class GetVendorOrderVendorSelectionByIdQuery : IQuery<Result<VendorOrderVendorSelectionDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderVendorSelectionByIdQueryHandler : IQueryHandler<GetVendorOrderVendorSelectionByIdQuery, Result<VendorOrderVendorSelectionDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderVendorSelectionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderVendorSelectionDetailsResponse>> Handle(GetVendorOrderVendorSelectionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderVendorSelectionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderVendorSelectionDetailsResponse>.Failure(Errors.VendorOrderVendorSelectionNotFound);

        var response = entity.Adapt<VendorOrderVendorSelectionDetailsResponse>();

        return Result<VendorOrderVendorSelectionDetailsResponse>.Success(response);
    }
}
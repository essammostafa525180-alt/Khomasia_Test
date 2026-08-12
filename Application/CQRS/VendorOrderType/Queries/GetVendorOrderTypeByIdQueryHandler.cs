using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderType.Queries;

public class GetVendorOrderTypeByIdQuery : IQuery<Result<VendorOrderTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderTypeByIdQueryHandler : IQueryHandler<GetVendorOrderTypeByIdQuery, Result<VendorOrderTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderTypeDetailsResponse>> Handle(GetVendorOrderTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderTypeDetailsResponse>.Failure(Errors.VendorOrderTypeNotFound);

        var response = entity.Adapt<VendorOrderTypeDetailsResponse>();

        return Result<VendorOrderTypeDetailsResponse>.Success(response);
    }
}
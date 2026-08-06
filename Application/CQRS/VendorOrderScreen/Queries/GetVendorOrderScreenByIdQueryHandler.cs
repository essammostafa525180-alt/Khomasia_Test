using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderScreen.Queries;

public class GetVendorOrderScreenByIdQuery : IQuery<Result<VendorOrderScreenDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderScreenByIdQueryHandler : IQueryHandler<GetVendorOrderScreenByIdQuery, Result<VendorOrderScreenDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderScreenByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderScreenDetailsResponse>> Handle(GetVendorOrderScreenByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderScreenRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderScreenDetailsResponse>.Failure(Errors.VendorOrderScreenNotFound);

        var response = entity.Adapt<VendorOrderScreenDetailsResponse>();

        return Result<VendorOrderScreenDetailsResponse>.Success(response);
    }
}
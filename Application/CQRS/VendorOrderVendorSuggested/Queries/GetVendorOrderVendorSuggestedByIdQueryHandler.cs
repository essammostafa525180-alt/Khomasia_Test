using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderVendorSuggested.Queries;

public class GetVendorOrderVendorSuggestedByIdQuery : IQuery<Result<VendorOrderVendorSuggestedDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderVendorSuggestedByIdQueryHandler : IQueryHandler<GetVendorOrderVendorSuggestedByIdQuery, Result<VendorOrderVendorSuggestedDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderVendorSuggestedByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderVendorSuggestedDetailsResponse>> Handle(GetVendorOrderVendorSuggestedByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderVendorSuggestedRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderVendorSuggestedDetailsResponse>.Failure(Errors.VendorOrderVendorSuggestedNotFound);

        var response = entity.Adapt<VendorOrderVendorSuggestedDetailsResponse>();

        return Result<VendorOrderVendorSuggestedDetailsResponse>.Success(response);
    }
}
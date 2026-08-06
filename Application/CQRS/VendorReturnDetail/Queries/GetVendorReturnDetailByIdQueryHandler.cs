using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorReturnDetail.Queries;

public class GetVendorReturnDetailByIdQuery : IQuery<Result<VendorReturnDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorReturnDetailByIdQueryHandler : IQueryHandler<GetVendorReturnDetailByIdQuery, Result<VendorReturnDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorReturnDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorReturnDetailDetailsResponse>> Handle(GetVendorReturnDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorReturnDetailDetailsResponse>.Failure(Errors.VendorReturnDetailNotFound);

        var response = entity.Adapt<VendorReturnDetailDetailsResponse>();

        return Result<VendorReturnDetailDetailsResponse>.Success(response);
    }
}
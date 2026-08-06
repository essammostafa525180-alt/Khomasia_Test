using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorType.Queries;

public class GetVendorTypeByIdQuery : IQuery<Result<VendorTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorTypeByIdQueryHandler : IQueryHandler<GetVendorTypeByIdQuery, Result<VendorTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorTypeDetailsResponse>> Handle(GetVendorTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorTypeDetailsResponse>.Failure(Errors.VendorTypeNotFound);

        var response = entity.Adapt<VendorTypeDetailsResponse>();

        return Result<VendorTypeDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorStatus.Queries;

public class GetVendorStatusByIdQuery : IQuery<Result<VendorStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorStatusByIdQueryHandler : IQueryHandler<GetVendorStatusByIdQuery, Result<VendorStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorStatusDetailsResponse>> Handle(GetVendorStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorStatusDetailsResponse>.Failure(Errors.VendorStatusNotFound);

        var response = entity.Adapt<VendorStatusDetailsResponse>();

        return Result<VendorStatusDetailsResponse>.Success(response);
    }
}
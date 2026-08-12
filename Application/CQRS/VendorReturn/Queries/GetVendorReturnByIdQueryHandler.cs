using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorReturn.Queries;

public class GetVendorReturnByIdQuery : IQuery<Result<VendorReturnDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorReturnByIdQueryHandler : IQueryHandler<GetVendorReturnByIdQuery, Result<VendorReturnDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorReturnByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorReturnDetailsResponse>> Handle(GetVendorReturnByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorReturnDetailsResponse>.Failure(Errors.VendorReturnNotFound);

        var response = entity.Adapt<VendorReturnDetailsResponse>();

        return Result<VendorReturnDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorReturnDetailBatch.Queries;

public class GetVendorReturnDetailBatchByIdQuery : IQuery<Result<VendorReturnDetailBatchDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorReturnDetailBatchByIdQueryHandler : IQueryHandler<GetVendorReturnDetailBatchByIdQuery, Result<VendorReturnDetailBatchDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorReturnDetailBatchByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorReturnDetailBatchDetailsResponse>> Handle(GetVendorReturnDetailBatchByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnDetailBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorReturnDetailBatchDetailsResponse>.Failure(Errors.VendorReturnDetailBatchNotFound);

        var response = entity.Adapt<VendorReturnDetailBatchDetailsResponse>();

        return Result<VendorReturnDetailBatchDetailsResponse>.Success(response);
    }
}
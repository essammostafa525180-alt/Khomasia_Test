using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AnnualStockCountItemMerge.Queries;

public class GetAnnualStockCountItemMergeByIdQuery : IQuery<Result<AnnualStockCountItemMergeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAnnualStockCountItemMergeByIdQueryHandler : IQueryHandler<GetAnnualStockCountItemMergeByIdQuery, Result<AnnualStockCountItemMergeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAnnualStockCountItemMergeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AnnualStockCountItemMergeDetailsResponse>> Handle(GetAnnualStockCountItemMergeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AnnualStockCountItemMergeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AnnualStockCountItemMergeDetailsResponse>.Failure(Errors.AnnualStockCountItemMergeNotFound);

        var response = entity.Adapt<AnnualStockCountItemMergeDetailsResponse>();

        return Result<AnnualStockCountItemMergeDetailsResponse>.Success(response);
    }
}
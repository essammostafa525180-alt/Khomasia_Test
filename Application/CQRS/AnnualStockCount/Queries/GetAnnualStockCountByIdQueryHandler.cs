using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AnnualStockCount.Queries;

public class GetAnnualStockCountByIdQuery : IQuery<Result<AnnualStockCountDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAnnualStockCountByIdQueryHandler : IQueryHandler<GetAnnualStockCountByIdQuery, Result<AnnualStockCountDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAnnualStockCountByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AnnualStockCountDetailsResponse>> Handle(GetAnnualStockCountByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AnnualStockCountRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AnnualStockCountDetailsResponse>.Failure(Errors.AnnualStockCountNotFound);

        var response = entity.Adapt<AnnualStockCountDetailsResponse>();

        return Result<AnnualStockCountDetailsResponse>.Success(response);
    }
}
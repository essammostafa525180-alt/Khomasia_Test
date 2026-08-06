using Application.Abstractions;
using Mapster;

namespace Application.CQRS.CostCenter.Queries;

public class GetCostCenterByIdQuery : IQuery<Result<CostCenterDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetCostCenterByIdQueryHandler : IQueryHandler<GetCostCenterByIdQuery, Result<CostCenterDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCostCenterByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CostCenterDetailsResponse>> Handle(GetCostCenterByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CostCenterRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<CostCenterDetailsResponse>.Failure(Errors.CostCenterNotFound);

        var response = entity.Adapt<CostCenterDetailsResponse>();

        return Result<CostCenterDetailsResponse>.Success(response);
    }
}
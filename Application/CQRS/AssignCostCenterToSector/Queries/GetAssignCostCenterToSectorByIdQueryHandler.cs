using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssignCostCenterToSector.Queries;

public class GetAssignCostCenterToSectorByIdQuery : IQuery<Result<AssignCostCenterToSectorDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssignCostCenterToSectorByIdQueryHandler : IQueryHandler<GetAssignCostCenterToSectorByIdQuery, Result<AssignCostCenterToSectorDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssignCostCenterToSectorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssignCostCenterToSectorDetailsResponse>> Handle(GetAssignCostCenterToSectorByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssignCostCenterToSectorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssignCostCenterToSectorDetailsResponse>.Failure(Errors.AssignCostCenterToSectorNotFound);

        var response = entity.Adapt<AssignCostCenterToSectorDetailsResponse>();

        return Result<AssignCostCenterToSectorDetailsResponse>.Success(response);
    }
}
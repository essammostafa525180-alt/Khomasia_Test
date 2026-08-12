using Application.Abstractions;
using Mapster;

namespace Application.CQRS.BatteryType.Queries;

public class GetBatteryTypeByIdQuery : IQuery<Result<BatteryTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetBatteryTypeByIdQueryHandler : IQueryHandler<GetBatteryTypeByIdQuery, Result<BatteryTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBatteryTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<BatteryTypeDetailsResponse>> Handle(GetBatteryTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.BatteryTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<BatteryTypeDetailsResponse>.Failure(Errors.BatteryTypeNotFound);

        var response = entity.Adapt<BatteryTypeDetailsResponse>();

        return Result<BatteryTypeDetailsResponse>.Success(response);
    }
}
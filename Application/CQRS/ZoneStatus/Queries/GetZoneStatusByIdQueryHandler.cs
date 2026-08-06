using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ZoneStatus.Queries;

public class GetZoneStatusByIdQuery : IQuery<Result<ZoneStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetZoneStatusByIdQueryHandler : IQueryHandler<GetZoneStatusByIdQuery, Result<ZoneStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetZoneStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ZoneStatusDetailsResponse>> Handle(GetZoneStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ZoneStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ZoneStatusDetailsResponse>.Failure(Errors.ZoneStatusNotFound);

        var response = entity.Adapt<ZoneStatusDetailsResponse>();

        return Result<ZoneStatusDetailsResponse>.Success(response);
    }
}
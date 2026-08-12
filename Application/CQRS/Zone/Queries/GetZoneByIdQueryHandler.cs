using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Zone.Queries;

public class GetZoneByIdQuery : IQuery<Result<ZoneDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetZoneByIdQueryHandler : IQueryHandler<GetZoneByIdQuery, Result<ZoneDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetZoneByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ZoneDetailsResponse>> Handle(GetZoneByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ZoneRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ZoneDetailsResponse>.Failure(Errors.ZoneNotFound);

        var response = entity.Adapt<ZoneDetailsResponse>();

        return Result<ZoneDetailsResponse>.Success(response);
    }
}
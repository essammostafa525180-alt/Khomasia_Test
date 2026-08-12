using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Location.Queries;

public class GetLocationByIdQuery : IQuery<Result<LocationDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetLocationByIdQueryHandler : IQueryHandler<GetLocationByIdQuery, Result<LocationDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLocationByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<LocationDetailsResponse>> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.LocationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<LocationDetailsResponse>.Failure(Errors.LocationNotFound);

        var response = entity.Adapt<LocationDetailsResponse>();

        return Result<LocationDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.City.Queries;

public class GetCityByIdQuery : IQuery<Result<CityDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetCityByIdQueryHandler : IQueryHandler<GetCityByIdQuery, Result<CityDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCityByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CityDetailsResponse>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<CityDetailsResponse>.Failure(Errors.CityNotFound);

        var response = entity.Adapt<CityDetailsResponse>();

        return Result<CityDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AirFilterType.Queries;

public class GetAirFilterTypeByIdQuery : IQuery<Result<AirFilterTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAirFilterTypeByIdQueryHandler : IQueryHandler<GetAirFilterTypeByIdQuery, Result<AirFilterTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAirFilterTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AirFilterTypeDetailsResponse>> Handle(GetAirFilterTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AirFilterTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AirFilterTypeDetailsResponse>.Failure(Errors.AirFilterTypeNotFound);

        var response = entity.Adapt<AirFilterTypeDetailsResponse>();

        return Result<AirFilterTypeDetailsResponse>.Success(response);
    }
}
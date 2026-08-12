using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Sector.Queries;

public class GetSectorByIdQuery : IQuery<Result<SectorDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSectorByIdQueryHandler : IQueryHandler<GetSectorByIdQuery, Result<SectorDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSectorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SectorDetailsResponse>> Handle(GetSectorByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SectorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SectorDetailsResponse>.Failure(Errors.SectorNotFound);

        var response = entity.Adapt<SectorDetailsResponse>();

        return Result<SectorDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.UnitOfMeasure.Queries;

public class GetUnitOfMeasureByIdQuery : IQuery<Result<UnitOfMeasureDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetUnitOfMeasureByIdQueryHandler : IQueryHandler<GetUnitOfMeasureByIdQuery, Result<UnitOfMeasureDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUnitOfMeasureByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<UnitOfMeasureDetailsResponse>> Handle(GetUnitOfMeasureByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.UnitOfMeasureRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<UnitOfMeasureDetailsResponse>.Failure(Errors.UnitOfMeasureNotFound);

        var response = entity.Adapt<UnitOfMeasureDetailsResponse>();

        return Result<UnitOfMeasureDetailsResponse>.Success(response);
    }
}
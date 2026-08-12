using Application.Abstractions;
using Mapster;

namespace Application.CQRS.DaysOfWeek.Queries;

public class GetDaysOfWeekByIdQuery : IQuery<Result<DaysOfWeekDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetDaysOfWeekByIdQueryHandler : IQueryHandler<GetDaysOfWeekByIdQuery, Result<DaysOfWeekDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDaysOfWeekByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<DaysOfWeekDetailsResponse>> Handle(GetDaysOfWeekByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.DaysOfWeekRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<DaysOfWeekDetailsResponse>.Failure(Errors.DaysOfWeekNotFound);

        var response = entity.Adapt<DaysOfWeekDetailsResponse>();

        return Result<DaysOfWeekDetailsResponse>.Success(response);
    }
}
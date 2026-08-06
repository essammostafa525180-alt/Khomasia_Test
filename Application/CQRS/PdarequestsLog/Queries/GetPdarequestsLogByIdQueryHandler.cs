using Application.Abstractions;
using Mapster;

namespace Application.CQRS.PdarequestsLog.Queries;

public class GetPdarequestsLogByIdQuery : IQuery<Result<PdarequestsLogDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetPdarequestsLogByIdQueryHandler : IQueryHandler<GetPdarequestsLogByIdQuery, Result<PdarequestsLogDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPdarequestsLogByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PdarequestsLogDetailsResponse>> Handle(GetPdarequestsLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PdarequestsLogRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<PdarequestsLogDetailsResponse>.Failure(Errors.PdarequestsLogNotFound);

        var response = entity.Adapt<PdarequestsLogDetailsResponse>();

        return Result<PdarequestsLogDetailsResponse>.Success(response);
    }
}
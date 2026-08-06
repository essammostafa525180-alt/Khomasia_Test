using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Visit.Queries;

public class GetVisitByIdQuery : IQuery<Result<VisitDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVisitByIdQueryHandler : IQueryHandler<GetVisitByIdQuery, Result<VisitDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVisitByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VisitDetailsResponse>> Handle(GetVisitByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VisitRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VisitDetailsResponse>.Failure(Errors.VisitNotFound);

        var response = entity.Adapt<VisitDetailsResponse>();

        return Result<VisitDetailsResponse>.Success(response);
    }
}
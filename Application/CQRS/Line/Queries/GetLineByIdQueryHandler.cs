using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Line.Queries;

public class GetLineByIdQuery : IQuery<Result<LineDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetLineByIdQueryHandler : IQueryHandler<GetLineByIdQuery, Result<LineDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLineByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<LineDetailsResponse>> Handle(GetLineByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.LineRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<LineDetailsResponse>.Failure(Errors.LineNotFound);

        var response = entity.Adapt<LineDetailsResponse>();

        return Result<LineDetailsResponse>.Success(response);
    }
}
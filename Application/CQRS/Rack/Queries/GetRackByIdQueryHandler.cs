using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Rack.Queries;

public class GetRackByIdQuery : IQuery<Result<RackDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetRackByIdQueryHandler : IQueryHandler<GetRackByIdQuery, Result<RackDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRackByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<RackDetailsResponse>> Handle(GetRackByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RackRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<RackDetailsResponse>.Failure(Errors.RackNotFound);

        var response = entity.Adapt<RackDetailsResponse>();

        return Result<RackDetailsResponse>.Success(response);
    }
}
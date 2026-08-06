using Application.Abstractions;
using Mapster;

namespace Application.CQRS.WsLastSyncTable.Queries;

public class GetWsLastSyncTableByIdQuery : IQuery<Result<WsLastSyncTableDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetWsLastSyncTableByIdQueryHandler : IQueryHandler<GetWsLastSyncTableByIdQuery, Result<WsLastSyncTableDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetWsLastSyncTableByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<WsLastSyncTableDetailsResponse>> Handle(GetWsLastSyncTableByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WsLastSyncTableRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<WsLastSyncTableDetailsResponse>.Failure(Errors.WsLastSyncTableNotFound);

        var response = entity.Adapt<WsLastSyncTableDetailsResponse>();

        return Result<WsLastSyncTableDetailsResponse>.Success(response);
    }
}
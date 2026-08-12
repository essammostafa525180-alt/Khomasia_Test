using Application.Abstractions;
using Mapster;

namespace Application.CQRS.RwPickedBatch.Queries;

public class GetRwPickedBatchByIdQuery : IQuery<Result<RwPickedBatchDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetRwPickedBatchByIdQueryHandler : IQueryHandler<GetRwPickedBatchByIdQuery, Result<RwPickedBatchDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRwPickedBatchByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<RwPickedBatchDetailsResponse>> Handle(GetRwPickedBatchByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwPickedBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<RwPickedBatchDetailsResponse>.Failure(Errors.RwPickedBatchNotFound);

        var response = entity.Adapt<RwPickedBatchDetailsResponse>();

        return Result<RwPickedBatchDetailsResponse>.Success(response);
    }
}
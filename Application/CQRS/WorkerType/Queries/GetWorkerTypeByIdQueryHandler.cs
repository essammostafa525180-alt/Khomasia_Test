using Application.Abstractions;
using Mapster;

namespace Application.CQRS.WorkerType.Queries;

public class GetWorkerTypeByIdQuery : IQuery<Result<WorkerTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetWorkerTypeByIdQueryHandler : IQueryHandler<GetWorkerTypeByIdQuery, Result<WorkerTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetWorkerTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<WorkerTypeDetailsResponse>> Handle(GetWorkerTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WorkerTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<WorkerTypeDetailsResponse>.Failure(Errors.WorkerTypeNotFound);

        var response = entity.Adapt<WorkerTypeDetailsResponse>();

        return Result<WorkerTypeDetailsResponse>.Success(response);
    }
}
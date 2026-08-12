using Application.Abstractions;
using Mapster;

namespace Application.CQRS.StoreSequence.Queries;

public class GetStoreSequenceByIdQuery : IQuery<Result<StoreSequenceDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetStoreSequenceByIdQueryHandler : IQueryHandler<GetStoreSequenceByIdQuery, Result<StoreSequenceDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetStoreSequenceByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<StoreSequenceDetailsResponse>> Handle(GetStoreSequenceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StoreSequenceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<StoreSequenceDetailsResponse>.Failure(Errors.StoreSequenceNotFound);

        var response = entity.Adapt<StoreSequenceDetailsResponse>();

        return Result<StoreSequenceDetailsResponse>.Success(response);
    }
}
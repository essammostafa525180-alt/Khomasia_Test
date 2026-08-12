using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Pruser.Queries;

public class GetPruserByIdQuery : IQuery<Result<PruserDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetPruserByIdQueryHandler : IQueryHandler<GetPruserByIdQuery, Result<PruserDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPruserByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PruserDetailsResponse>> Handle(GetPruserByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PruserRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<PruserDetailsResponse>.Failure(Errors.PruserNotFound);

        var response = entity.Adapt<PruserDetailsResponse>();

        return Result<PruserDetailsResponse>.Success(response);
    }
}
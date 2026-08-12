using Application.Abstractions;
using Mapster;

namespace Application.CQRS.PossessionType.Queries;

public class GetPossessionTypeByIdQuery : IQuery<Result<PossessionTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetPossessionTypeByIdQueryHandler : IQueryHandler<GetPossessionTypeByIdQuery, Result<PossessionTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPossessionTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PossessionTypeDetailsResponse>> Handle(GetPossessionTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PossessionTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<PossessionTypeDetailsResponse>.Failure(Errors.PossessionTypeNotFound);

        var response = entity.Adapt<PossessionTypeDetailsResponse>();

        return Result<PossessionTypeDetailsResponse>.Success(response);
    }
}
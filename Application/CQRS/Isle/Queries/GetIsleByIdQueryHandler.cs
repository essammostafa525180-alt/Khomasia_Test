using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Isle.Queries;

public class GetIsleByIdQuery : IQuery<Result<IsleDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetIsleByIdQueryHandler : IQueryHandler<GetIsleByIdQuery, Result<IsleDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetIsleByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IsleDetailsResponse>> Handle(GetIsleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.IsleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<IsleDetailsResponse>.Failure(Errors.IsleNotFound);

        var response = entity.Adapt<IsleDetailsResponse>();

        return Result<IsleDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Ou.Queries;

public class GetOuByIdQuery : IQuery<Result<OuDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetOuByIdQueryHandler : IQueryHandler<GetOuByIdQuery, Result<OuDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOuByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<OuDetailsResponse>> Handle(GetOuByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.OuRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<OuDetailsResponse>.Failure(Errors.OuNotFound);

        var response = entity.Adapt<OuDetailsResponse>();

        return Result<OuDetailsResponse>.Success(response);
    }
}
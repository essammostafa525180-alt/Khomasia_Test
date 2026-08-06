using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Oil.Queries;

public class GetOilByIdQuery : IQuery<Result<OilDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetOilByIdQueryHandler : IQueryHandler<GetOilByIdQuery, Result<OilDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOilByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<OilDetailsResponse>> Handle(GetOilByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.OilRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<OilDetailsResponse>.Failure(Errors.OilNotFound);

        var response = entity.Adapt<OilDetailsResponse>();

        return Result<OilDetailsResponse>.Success(response);
    }
}
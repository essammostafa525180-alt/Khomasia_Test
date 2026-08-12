using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Rank.Queries;

public class GetRankByIdQuery : IQuery<Result<RankDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetRankByIdQueryHandler : IQueryHandler<GetRankByIdQuery, Result<RankDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRankByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<RankDetailsResponse>> Handle(GetRankByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RankRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<RankDetailsResponse>.Failure(Errors.RankNotFound);

        var response = entity.Adapt<RankDetailsResponse>();

        return Result<RankDetailsResponse>.Success(response);
    }
}
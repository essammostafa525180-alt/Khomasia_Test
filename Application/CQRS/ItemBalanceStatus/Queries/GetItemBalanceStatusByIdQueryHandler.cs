using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ItemBalanceStatus.Queries;

public class GetItemBalanceStatusByIdQuery : IQuery<Result<ItemBalanceStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetItemBalanceStatusByIdQueryHandler : IQueryHandler<GetItemBalanceStatusByIdQuery, Result<ItemBalanceStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetItemBalanceStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ItemBalanceStatusDetailsResponse>> Handle(GetItemBalanceStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ItemBalanceStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ItemBalanceStatusDetailsResponse>.Failure(Errors.ItemBalanceStatusNotFound);

        var response = entity.Adapt<ItemBalanceStatusDetailsResponse>();

        return Result<ItemBalanceStatusDetailsResponse>.Success(response);
    }
}
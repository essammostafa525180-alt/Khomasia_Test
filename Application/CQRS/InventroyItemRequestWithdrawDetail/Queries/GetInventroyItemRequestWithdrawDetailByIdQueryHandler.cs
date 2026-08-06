using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventroyItemRequestWithdrawDetail.Queries;

public class GetInventroyItemRequestWithdrawDetailByIdQuery : IQuery<Result<InventroyItemRequestWithdrawDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventroyItemRequestWithdrawDetailByIdQueryHandler : IQueryHandler<GetInventroyItemRequestWithdrawDetailByIdQuery, Result<InventroyItemRequestWithdrawDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventroyItemRequestWithdrawDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventroyItemRequestWithdrawDetailDetailsResponse>> Handle(GetInventroyItemRequestWithdrawDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventroyItemRequestWithdrawDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventroyItemRequestWithdrawDetailDetailsResponse>.Failure(Errors.InventroyItemRequestWithdrawDetailNotFound);

        var response = entity.Adapt<InventroyItemRequestWithdrawDetailDetailsResponse>();

        return Result<InventroyItemRequestWithdrawDetailDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventroyItemRequestWithdraw.Queries;

public class GetInventroyItemRequestWithdrawByIdQuery : IQuery<Result<InventroyItemRequestWithdrawDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventroyItemRequestWithdrawByIdQueryHandler : IQueryHandler<GetInventroyItemRequestWithdrawByIdQuery, Result<InventroyItemRequestWithdrawDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventroyItemRequestWithdrawByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventroyItemRequestWithdrawDetailsResponse>> Handle(GetInventroyItemRequestWithdrawByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventroyItemRequestWithdrawRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventroyItemRequestWithdrawDetailsResponse>.Failure(Errors.InventroyItemRequestWithdrawNotFound);

        var response = entity.Adapt<InventroyItemRequestWithdrawDetailsResponse>();

        return Result<InventroyItemRequestWithdrawDetailsResponse>.Success(response);
    }
}
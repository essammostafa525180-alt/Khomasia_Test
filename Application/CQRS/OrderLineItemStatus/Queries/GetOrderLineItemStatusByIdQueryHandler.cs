using Application.Abstractions;
using Mapster;

namespace Application.CQRS.OrderLineItemStatus.Queries;

public class GetOrderLineItemStatusByIdQuery : IQuery<Result<OrderLineItemStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetOrderLineItemStatusByIdQueryHandler : IQueryHandler<GetOrderLineItemStatusByIdQuery, Result<OrderLineItemStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOrderLineItemStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<OrderLineItemStatusDetailsResponse>> Handle(GetOrderLineItemStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.OrderLineItemStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<OrderLineItemStatusDetailsResponse>.Failure(Errors.OrderLineItemStatusNotFound);

        var response = entity.Adapt<OrderLineItemStatusDetailsResponse>();

        return Result<OrderLineItemStatusDetailsResponse>.Success(response);
    }
}
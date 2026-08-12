using Application.Abstractions;
using Mapster;

namespace Application.CQRS.RequestLineItemStatus.Queries;

public class GetRequestLineItemStatusByIdQuery : IQuery<Result<RequestLineItemStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetRequestLineItemStatusByIdQueryHandler : IQueryHandler<GetRequestLineItemStatusByIdQuery, Result<RequestLineItemStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRequestLineItemStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<RequestLineItemStatusDetailsResponse>> Handle(GetRequestLineItemStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RequestLineItemStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<RequestLineItemStatusDetailsResponse>.Failure(Errors.RequestLineItemStatusNotFound);

        var response = entity.Adapt<RequestLineItemStatusDetailsResponse>();

        return Result<RequestLineItemStatusDetailsResponse>.Success(response);
    }
}
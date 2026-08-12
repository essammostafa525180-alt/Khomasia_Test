using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ItemRequestStatus.Queries;

public class GetItemRequestStatusByIdQuery : IQuery<Result<ItemRequestStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetItemRequestStatusByIdQueryHandler : IQueryHandler<GetItemRequestStatusByIdQuery, Result<ItemRequestStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetItemRequestStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ItemRequestStatusDetailsResponse>> Handle(GetItemRequestStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ItemRequestStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ItemRequestStatusDetailsResponse>.Failure(Errors.ItemRequestStatusNotFound);

        var response = entity.Adapt<ItemRequestStatusDetailsResponse>();

        return Result<ItemRequestStatusDetailsResponse>.Success(response);
    }
}
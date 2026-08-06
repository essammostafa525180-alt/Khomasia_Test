using Application.Abstractions;
using Mapster;

namespace Application.CQRS.NotificationPlaceHolder.Queries;

public class GetNotificationPlaceHolderByIdQuery : IQuery<Result<NotificationPlaceHolderDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetNotificationPlaceHolderByIdQueryHandler : IQueryHandler<GetNotificationPlaceHolderByIdQuery, Result<NotificationPlaceHolderDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetNotificationPlaceHolderByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<NotificationPlaceHolderDetailsResponse>> Handle(GetNotificationPlaceHolderByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationPlaceHolderRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<NotificationPlaceHolderDetailsResponse>.Failure(Errors.NotificationPlaceHolderNotFound);

        var response = entity.Adapt<NotificationPlaceHolderDetailsResponse>();

        return Result<NotificationPlaceHolderDetailsResponse>.Success(response);
    }
}
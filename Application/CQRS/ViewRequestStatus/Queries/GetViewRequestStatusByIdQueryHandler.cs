using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ViewRequestStatus.Queries;

public class GetViewRequestStatusByIdQuery : IQuery<Result<ViewRequestStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetViewRequestStatusByIdQueryHandler : IQueryHandler<GetViewRequestStatusByIdQuery, Result<ViewRequestStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetViewRequestStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ViewRequestStatusDetailsResponse>> Handle(GetViewRequestStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ViewRequestStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ViewRequestStatusDetailsResponse>.Failure(Errors.ViewRequestStatusNotFound);

        var response = entity.Adapt<ViewRequestStatusDetailsResponse>();

        return Result<ViewRequestStatusDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.UserSessionInfoDetail.Queries;

public class GetUserSessionInfoDetailByIdQuery : IQuery<Result<UserSessionInfoDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetUserSessionInfoDetailByIdQueryHandler : IQueryHandler<GetUserSessionInfoDetailByIdQuery, Result<UserSessionInfoDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserSessionInfoDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<UserSessionInfoDetailDetailsResponse>> Handle(GetUserSessionInfoDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.UserSessionInfoDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<UserSessionInfoDetailDetailsResponse>.Failure(Errors.UserSessionInfoDetailNotFound);

        var response = entity.Adapt<UserSessionInfoDetailDetailsResponse>();

        return Result<UserSessionInfoDetailDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.UserSessionInfo.Queries;

public class GetUserSessionInfoByIdQuery : IQuery<Result<UserSessionInfoDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetUserSessionInfoByIdQueryHandler : IQueryHandler<GetUserSessionInfoByIdQuery, Result<UserSessionInfoDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserSessionInfoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<UserSessionInfoDetailsResponse>> Handle(GetUserSessionInfoByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.UserSessionInfoRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<UserSessionInfoDetailsResponse>.Failure(Errors.UserSessionInfoNotFound);

        var response = entity.Adapt<UserSessionInfoDetailsResponse>();

        return Result<UserSessionInfoDetailsResponse>.Success(response);
    }
}
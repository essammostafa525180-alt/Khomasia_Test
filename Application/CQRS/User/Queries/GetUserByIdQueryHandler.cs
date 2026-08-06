using Application.Abstractions;
using Mapster;

namespace Application.CQRS.User.Queries;

public class GetUserByIdQuery : IQuery<Result<UserDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, Result<UserDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<UserDetailsResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<UserDetailsResponse>.Failure(Errors.UserNotFound);

        var response = entity.Adapt<UserDetailsResponse>();

        return Result<UserDetailsResponse>.Success(response);
    }
}
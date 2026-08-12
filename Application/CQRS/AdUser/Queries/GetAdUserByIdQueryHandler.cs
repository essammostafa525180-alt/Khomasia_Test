using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AdUser.Queries;

public class GetAdUserByIdQuery : IQuery<Result<AdUserDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAdUserByIdQueryHandler : IQueryHandler<GetAdUserByIdQuery, Result<AdUserDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAdUserByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AdUserDetailsResponse>> Handle(GetAdUserByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AdUserRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AdUserDetailsResponse>.Failure(Errors.AdUserNotFound);

        var response = entity.Adapt<AdUserDetailsResponse>();

        return Result<AdUserDetailsResponse>.Success(response);
    }
}
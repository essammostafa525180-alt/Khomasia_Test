using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecRole.Queries;

public class GetSecRoleByIdQuery : IQuery<Result<SecRoleDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecRoleByIdQueryHandler : IQueryHandler<GetSecRoleByIdQuery, Result<SecRoleDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecRoleByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecRoleDetailsResponse>> Handle(GetSecRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRoleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecRoleDetailsResponse>.Failure(Errors.SecRoleNotFound);

        var response = entity.Adapt<SecRoleDetailsResponse>();

        return Result<SecRoleDetailsResponse>.Success(response);
    }
}
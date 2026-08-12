using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecRoleModule.Queries;

public class GetSecRoleModuleByIdQuery : IQuery<Result<SecRoleModuleDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecRoleModuleByIdQueryHandler : IQueryHandler<GetSecRoleModuleByIdQuery, Result<SecRoleModuleDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecRoleModuleByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecRoleModuleDetailsResponse>> Handle(GetSecRoleModuleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRoleModuleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecRoleModuleDetailsResponse>.Failure(Errors.SecRoleModuleNotFound);

        var response = entity.Adapt<SecRoleModuleDetailsResponse>();

        return Result<SecRoleModuleDetailsResponse>.Success(response);
    }
}
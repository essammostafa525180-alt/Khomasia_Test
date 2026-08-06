using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecRoleViewAction.Queries;

public class GetSecRoleViewActionByIdQuery : IQuery<Result<SecRoleViewActionDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecRoleViewActionByIdQueryHandler : IQueryHandler<GetSecRoleViewActionByIdQuery, Result<SecRoleViewActionDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecRoleViewActionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecRoleViewActionDetailsResponse>> Handle(GetSecRoleViewActionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRoleViewActionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecRoleViewActionDetailsResponse>.Failure(Errors.SecRoleViewActionNotFound);

        var response = entity.Adapt<SecRoleViewActionDetailsResponse>();

        return Result<SecRoleViewActionDetailsResponse>.Success(response);
    }
}
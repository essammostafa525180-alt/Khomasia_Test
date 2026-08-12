using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecRoleProperty.Queries;

public class GetSecRolePropertyByIdQuery : IQuery<Result<SecRolePropertyDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecRolePropertyByIdQueryHandler : IQueryHandler<GetSecRolePropertyByIdQuery, Result<SecRolePropertyDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecRolePropertyByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecRolePropertyDetailsResponse>> Handle(GetSecRolePropertyByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRolePropertyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecRolePropertyDetailsResponse>.Failure(Errors.SecRolePropertyNotFound);

        var response = entity.Adapt<SecRolePropertyDetailsResponse>();

        return Result<SecRolePropertyDetailsResponse>.Success(response);
    }
}
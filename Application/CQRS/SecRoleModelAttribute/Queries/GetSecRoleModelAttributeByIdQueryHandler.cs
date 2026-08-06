using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecRoleModelAttribute.Queries;

public class GetSecRoleModelAttributeByIdQuery : IQuery<Result<SecRoleModelAttributeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecRoleModelAttributeByIdQueryHandler : IQueryHandler<GetSecRoleModelAttributeByIdQuery, Result<SecRoleModelAttributeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecRoleModelAttributeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecRoleModelAttributeDetailsResponse>> Handle(GetSecRoleModelAttributeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRoleModelAttributeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecRoleModelAttributeDetailsResponse>.Failure(Errors.SecRoleModelAttributeNotFound);

        var response = entity.Adapt<SecRoleModelAttributeDetailsResponse>();

        return Result<SecRoleModelAttributeDetailsResponse>.Success(response);
    }
}
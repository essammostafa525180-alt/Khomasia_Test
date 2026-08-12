using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecRoleSecurableValue.Queries;

public class GetSecRoleSecurableValueByIdQuery : IQuery<Result<SecRoleSecurableValueDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecRoleSecurableValueByIdQueryHandler : IQueryHandler<GetSecRoleSecurableValueByIdQuery, Result<SecRoleSecurableValueDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecRoleSecurableValueByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecRoleSecurableValueDetailsResponse>> Handle(GetSecRoleSecurableValueByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRoleSecurableValueRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecRoleSecurableValueDetailsResponse>.Failure(Errors.SecRoleSecurableValueNotFound);

        var response = entity.Adapt<SecRoleSecurableValueDetailsResponse>();

        return Result<SecRoleSecurableValueDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecUserSecurableValue.Queries;

public class GetSecUserSecurableValueByIdQuery : IQuery<Result<SecUserSecurableValueDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecUserSecurableValueByIdQueryHandler : IQueryHandler<GetSecUserSecurableValueByIdQuery, Result<SecUserSecurableValueDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecUserSecurableValueByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecUserSecurableValueDetailsResponse>> Handle(GetSecUserSecurableValueByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecUserSecurableValueRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecUserSecurableValueDetailsResponse>.Failure(Errors.SecUserSecurableValueNotFound);

        var response = entity.Adapt<SecUserSecurableValueDetailsResponse>();

        return Result<SecUserSecurableValueDetailsResponse>.Success(response);
    }
}
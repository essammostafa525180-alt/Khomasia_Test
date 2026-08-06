using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecUserProperty.Queries;

public class GetSecUserPropertyByIdQuery : IQuery<Result<SecUserPropertyDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecUserPropertyByIdQueryHandler : IQueryHandler<GetSecUserPropertyByIdQuery, Result<SecUserPropertyDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecUserPropertyByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecUserPropertyDetailsResponse>> Handle(GetSecUserPropertyByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecUserPropertyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecUserPropertyDetailsResponse>.Failure(Errors.SecUserPropertyNotFound);

        var response = entity.Adapt<SecUserPropertyDetailsResponse>();

        return Result<SecUserPropertyDetailsResponse>.Success(response);
    }
}
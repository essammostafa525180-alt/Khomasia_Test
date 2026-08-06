using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Scope.Queries;

public class GetScopeByIdQuery : IQuery<Result<ScopeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetScopeByIdQueryHandler : IQueryHandler<GetScopeByIdQuery, Result<ScopeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetScopeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ScopeDetailsResponse>> Handle(GetScopeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ScopeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ScopeDetailsResponse>.Failure(Errors.ScopeNotFound);

        var response = entity.Adapt<ScopeDetailsResponse>();

        return Result<ScopeDetailsResponse>.Success(response);
    }
}
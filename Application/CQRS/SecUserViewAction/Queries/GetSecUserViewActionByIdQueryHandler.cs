using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecUserViewAction.Queries;

public class GetSecUserViewActionByIdQuery : IQuery<Result<SecUserViewActionDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecUserViewActionByIdQueryHandler : IQueryHandler<GetSecUserViewActionByIdQuery, Result<SecUserViewActionDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecUserViewActionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecUserViewActionDetailsResponse>> Handle(GetSecUserViewActionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecUserViewActionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecUserViewActionDetailsResponse>.Failure(Errors.SecUserViewActionNotFound);

        var response = entity.Adapt<SecUserViewActionDetailsResponse>();

        return Result<SecUserViewActionDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecProperty.Queries;

public class GetSecPropertyByIdQuery : IQuery<Result<SecPropertyDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecPropertyByIdQueryHandler : IQueryHandler<GetSecPropertyByIdQuery, Result<SecPropertyDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecPropertyByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecPropertyDetailsResponse>> Handle(GetSecPropertyByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecPropertyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecPropertyDetailsResponse>.Failure(Errors.SecPropertyNotFound);

        var response = entity.Adapt<SecPropertyDetailsResponse>();

        return Result<SecPropertyDetailsResponse>.Success(response);
    }
}
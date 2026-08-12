using Application.Abstractions;
using Mapster;

namespace Application.CQRS.EngineSize.Queries;

public class GetEngineSizeByIdQuery : IQuery<Result<EngineSizeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetEngineSizeByIdQueryHandler : IQueryHandler<GetEngineSizeByIdQuery, Result<EngineSizeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEngineSizeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<EngineSizeDetailsResponse>> Handle(GetEngineSizeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.EngineSizeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<EngineSizeDetailsResponse>.Failure(Errors.EngineSizeNotFound);

        var response = entity.Adapt<EngineSizeDetailsResponse>();

        return Result<EngineSizeDetailsResponse>.Success(response);
    }
}
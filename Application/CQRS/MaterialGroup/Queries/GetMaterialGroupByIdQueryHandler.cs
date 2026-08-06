using Application.Abstractions;
using Mapster;

namespace Application.CQRS.MaterialGroup.Queries;

public class GetMaterialGroupByIdQuery : IQuery<Result<MaterialGroupDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetMaterialGroupByIdQueryHandler : IQueryHandler<GetMaterialGroupByIdQuery, Result<MaterialGroupDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMaterialGroupByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<MaterialGroupDetailsResponse>> Handle(GetMaterialGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.MaterialGroupRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<MaterialGroupDetailsResponse>.Failure(Errors.MaterialGroupNotFound);

        var response = entity.Adapt<MaterialGroupDetailsResponse>();

        return Result<MaterialGroupDetailsResponse>.Success(response);
    }
}
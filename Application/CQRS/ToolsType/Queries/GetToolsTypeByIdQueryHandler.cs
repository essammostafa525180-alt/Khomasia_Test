using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ToolsType.Queries;

public class GetToolsTypeByIdQuery : IQuery<Result<ToolsTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetToolsTypeByIdQueryHandler : IQueryHandler<GetToolsTypeByIdQuery, Result<ToolsTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetToolsTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ToolsTypeDetailsResponse>> Handle(GetToolsTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ToolsTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ToolsTypeDetailsResponse>.Failure(Errors.ToolsTypeNotFound);

        var response = entity.Adapt<ToolsTypeDetailsResponse>();

        return Result<ToolsTypeDetailsResponse>.Success(response);
    }
}
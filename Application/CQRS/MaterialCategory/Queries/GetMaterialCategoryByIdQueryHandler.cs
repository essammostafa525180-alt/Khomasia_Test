using Application.Abstractions;
using Mapster;

namespace Application.CQRS.MaterialCategory.Queries;

public class GetMaterialCategoryByIdQuery : IQuery<Result<MaterialCategoryDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetMaterialCategoryByIdQueryHandler : IQueryHandler<GetMaterialCategoryByIdQuery, Result<MaterialCategoryDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMaterialCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<MaterialCategoryDetailsResponse>> Handle(GetMaterialCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.MaterialCategoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<MaterialCategoryDetailsResponse>.Failure(Errors.MaterialCategoryNotFound);

        var response = entity.Adapt<MaterialCategoryDetailsResponse>();

        return Result<MaterialCategoryDetailsResponse>.Success(response);
    }
}
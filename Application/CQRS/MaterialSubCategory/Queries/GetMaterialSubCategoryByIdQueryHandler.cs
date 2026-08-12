using Application.Abstractions;
using Mapster;

namespace Application.CQRS.MaterialSubCategory.Queries;

public class GetMaterialSubCategoryByIdQuery : IQuery<Result<MaterialSubCategoryDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetMaterialSubCategoryByIdQueryHandler : IQueryHandler<GetMaterialSubCategoryByIdQuery, Result<MaterialSubCategoryDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMaterialSubCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<MaterialSubCategoryDetailsResponse>> Handle(GetMaterialSubCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.MaterialSubCategoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<MaterialSubCategoryDetailsResponse>.Failure(Errors.MaterialSubCategoryNotFound);

        var response = entity.Adapt<MaterialSubCategoryDetailsResponse>();

        return Result<MaterialSubCategoryDetailsResponse>.Success(response);
    }
}
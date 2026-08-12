using Application.Abstractions;

namespace Application.CQRS.MaterialSubCategory.Commands;

public class CreateMaterialSubCategoryCommand : ICommand<Result<int>>
{
        public int? MaterialGroupFk { get; set; }
        public int? MaterialCategoryFk { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateMaterialSubCategoryCommandHandler : ICommandHandler<CreateMaterialSubCategoryCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMaterialSubCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateMaterialSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.MaterialSubCategory.Create(request.MaterialGroupFk, request.MaterialCategoryFk, request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.MaterialSubCategoryRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.MaterialSubCategoryNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.MaterialCategory.Commands;

public class UpdateMaterialCategoryCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? MaterialGroupFk { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateMaterialCategoryCommandHandler : ICommandHandler<UpdateMaterialCategoryCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMaterialCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateMaterialCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.MaterialCategoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.MaterialCategoryNotFound);

        entity.Update(request.MaterialGroupFk, request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.MaterialCategoryNotUpdated);
    }
}
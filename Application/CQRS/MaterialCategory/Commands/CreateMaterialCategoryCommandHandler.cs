using Application.Abstractions;

namespace Application.CQRS.MaterialCategory.Commands;

public class CreateMaterialCategoryCommand : ICommand<Result<int>>
{
        public int? MaterialGroupFk { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateMaterialCategoryCommandHandler : ICommandHandler<CreateMaterialCategoryCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMaterialCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateMaterialCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.MaterialCategory.Create(request.MaterialGroupFk, request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.MaterialCategoryRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.MaterialCategoryNotInserted);
    }
}
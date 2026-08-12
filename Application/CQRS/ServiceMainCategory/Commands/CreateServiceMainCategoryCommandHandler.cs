using Application.Abstractions;

namespace Application.CQRS.ServiceMainCategory.Commands;

public class CreateServiceMainCategoryCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? FinanceCostCenterId { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateServiceMainCategoryCommandHandler : ICommandHandler<CreateServiceMainCategoryCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateServiceMainCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateServiceMainCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ServiceMainCategory.Create(request.Code, request.Name, request.NameAr, request.FinanceCostCenterId, request.IsActive);

        await _unitOfWork.ServiceMainCategoryRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ServiceMainCategoryNotInserted);
    }
}
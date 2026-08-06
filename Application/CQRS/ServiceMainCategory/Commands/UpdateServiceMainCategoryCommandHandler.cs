using Application.Abstractions;

namespace Application.CQRS.ServiceMainCategory.Commands;

public class UpdateServiceMainCategoryCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? FinanceCostCenterId { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateServiceMainCategoryCommandHandler : ICommandHandler<UpdateServiceMainCategoryCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateServiceMainCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateServiceMainCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ServiceMainCategoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ServiceMainCategoryNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.FinanceCostCenterId, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ServiceMainCategoryNotUpdated);
    }
}
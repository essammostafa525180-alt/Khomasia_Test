using Application.Abstractions;

namespace Application.CQRS.Service.Commands;

public class UpdateServiceCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? ServiceTypeFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? ServiceCategoryFk { get; set; }
        public int? ServiceSubCategoryFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateServiceCommandHandler : ICommandHandler<UpdateServiceCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ServiceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ServiceNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.ServiceTypeFk, request.ServiceMainCategoryFk, request.ServiceCategoryFk, request.ServiceSubCategoryFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ServiceNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.InventoryCurrency.Commands;

public class UpdateInventoryCurrencyCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryCurrencyCommandHandler : ICommandHandler<UpdateInventoryCurrencyCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryCurrencyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryCurrencyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryCurrencyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryCurrencyNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryCurrencyNotUpdated);
    }
}
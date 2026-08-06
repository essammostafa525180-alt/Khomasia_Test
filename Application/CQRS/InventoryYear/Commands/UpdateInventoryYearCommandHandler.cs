using Application.Abstractions;

namespace Application.CQRS.InventoryYear.Commands;

public class UpdateInventoryYearCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryYearCommandHandler : ICommandHandler<UpdateInventoryYearCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryYearCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryYearCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryYearRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryYearNotFound);

        entity.Update(request.Name, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryYearNotUpdated);
    }
}
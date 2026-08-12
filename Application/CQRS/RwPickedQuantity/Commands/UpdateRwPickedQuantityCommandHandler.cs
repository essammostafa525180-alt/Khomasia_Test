using Application.Abstractions;

namespace Application.CQRS.RwPickedQuantity.Commands;

public class UpdateRwPickedQuantityCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? RequestWdfk { get; set; }
        public decimal? PickedQuantity { get; set; }
        public DateTime? PickedDate { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateRwPickedQuantityCommandHandler : ICommandHandler<UpdateRwPickedQuantityCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRwPickedQuantityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateRwPickedQuantityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwPickedQuantityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RwPickedQuantityNotFound);

        entity.Update(request.RequestWdfk, request.PickedQuantity, request.PickedDate, request.Axsynced, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RwPickedQuantityNotUpdated);
    }
}
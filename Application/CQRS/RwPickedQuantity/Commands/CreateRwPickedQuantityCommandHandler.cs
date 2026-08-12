using Application.Abstractions;

namespace Application.CQRS.RwPickedQuantity.Commands;

public class CreateRwPickedQuantityCommand : ICommand<Result<int>>
{
        public int? RequestWdfk { get; set; }
        public decimal? PickedQuantity { get; set; }
        public DateTime? PickedDate { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateRwPickedQuantityCommandHandler : ICommandHandler<CreateRwPickedQuantityCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRwPickedQuantityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateRwPickedQuantityCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.RequestAggregate.RwPickedQuantity.Create(request.RequestWdfk, request.PickedQuantity, request.PickedDate, request.Axsynced, request.IsActive);

        await _unitOfWork.RwPickedQuantityRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.RwPickedQuantityNotInserted);
    }
}
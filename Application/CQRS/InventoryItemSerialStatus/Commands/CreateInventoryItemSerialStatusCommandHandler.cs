using Application.Abstractions;

namespace Application.CQRS.InventoryItemSerialStatus.Commands;

public class CreateInventoryItemSerialStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemSerialStatusCommandHandler : ICommandHandler<CreateInventoryItemSerialStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemSerialStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemSerialStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.InventoryItemSerialStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.InventoryItemSerialStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemSerialStatusNotInserted);
    }
}
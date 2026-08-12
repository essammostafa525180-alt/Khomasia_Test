using Application.Abstractions;

namespace Application.CQRS.Warehouse.Commands;

public class CreateWarehouseCommand : ICommand<Result<int>>
{
        public int WarehouseTypeFk { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateWarehouseCommandHandler : ICommandHandler<CreateWarehouseCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateWarehouseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.Warehouse.Create(request.WarehouseTypeFk, request.Code, request.Name, request.Description, request.Address, request.IsActive);

        await _unitOfWork.WarehouseRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.WarehouseNotInserted);
    }
}

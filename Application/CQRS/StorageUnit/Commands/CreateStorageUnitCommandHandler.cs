using Application.Abstractions;
using Domain.Entities;

namespace Application.CQRS.StorageUnit.Commands;

public class CreateStorageUnitCommand : ICommand<Result<int>>
{
        public int WarehouseFk { get; set; }
        public StorageUnitType Type { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Capacity { get; set; }
        public string? CapacityUnit { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateStorageUnitCommandHandler : ICommandHandler<CreateStorageUnitCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStorageUnitCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateStorageUnitCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.StorageUnit.Create(request.WarehouseFk, request.Type, request.Code, request.Name, request.Description, request.Capacity, request.CapacityUnit, request.IsActive);

        await _unitOfWork.StorageUnitRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.StorageUnitNotInserted);
    }
}

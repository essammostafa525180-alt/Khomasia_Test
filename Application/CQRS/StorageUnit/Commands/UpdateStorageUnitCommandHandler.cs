using Application.Abstractions;
using Domain.Entities;

namespace Application.CQRS.StorageUnit.Commands;

public class UpdateStorageUnitCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int WarehouseFk { get; set; }
        public StorageUnitType Type { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Capacity { get; set; }
        public string? CapacityUnit { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateStorageUnitCommandHandler : ICommandHandler<UpdateStorageUnitCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStorageUnitCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateStorageUnitCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StorageUnitRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.StorageUnitNotFound);

        entity.Update(request.WarehouseFk, request.Type, request.Code, request.Name, request.Description, request.Capacity, request.CapacityUnit, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.StorageUnitNotUpdated);
    }
}

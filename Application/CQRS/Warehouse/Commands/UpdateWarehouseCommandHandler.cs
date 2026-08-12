using Application.Abstractions;

namespace Application.CQRS.Warehouse.Commands;

public class UpdateWarehouseCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int WarehouseTypeFk { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateWarehouseCommandHandler : ICommandHandler<UpdateWarehouseCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateWarehouseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WarehouseRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.WarehouseNotFound);

        entity.Update(request.WarehouseTypeFk, request.Code, request.Name, request.Description, request.Address, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.WarehouseNotUpdated);
    }
}

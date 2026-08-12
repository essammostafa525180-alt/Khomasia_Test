using Application.Abstractions;

namespace Application.CQRS.WarehouseType.Commands;

public class UpdateWarehouseTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateWarehouseTypeCommandHandler : ICommandHandler<UpdateWarehouseTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateWarehouseTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateWarehouseTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WarehouseTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.WarehouseTypeNotFound);

        entity.Update(request.Code, request.Name, request.Description, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.WarehouseTypeNotUpdated);
    }
}

using Application.Abstractions;

namespace Application.CQRS.WarehouseType.Commands;

public class CreateWarehouseTypeCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateWarehouseTypeCommandHandler : ICommandHandler<CreateWarehouseTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateWarehouseTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateWarehouseTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.WarehouseType.Create(request.Code, request.Name, request.Description, request.IsActive);

        await _unitOfWork.WarehouseTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.WarehouseTypeNotInserted);
    }
}

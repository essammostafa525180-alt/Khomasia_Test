using Application.Abstractions;

namespace Application.CQRS.InventoryYear.Commands;

public class CreateInventoryYearCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryYearCommandHandler : ICommandHandler<CreateInventoryYearCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryYearCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryYearCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.InventoryYear.Create(request.Name, request.IsActive);

        await _unitOfWork.InventoryYearRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryYearNotInserted);
    }
}
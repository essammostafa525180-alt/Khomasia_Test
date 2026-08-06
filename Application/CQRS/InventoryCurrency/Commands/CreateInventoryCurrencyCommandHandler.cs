using Application.Abstractions;

namespace Application.CQRS.InventoryCurrency.Commands;

public class CreateInventoryCurrencyCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryCurrencyCommandHandler : ICommandHandler<CreateInventoryCurrencyCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryCurrencyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryCurrencyCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.InventoryCurrency.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.InventoryCurrencyRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryCurrencyNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.ItemQuantityType.Commands;

public class CreateItemQuantityTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateItemQuantityTypeCommandHandler : ICommandHandler<CreateItemQuantityTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateItemQuantityTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateItemQuantityTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ItemQuantityType.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.ItemQuantityTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ItemQuantityTypeNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.ItemExpiryType.Commands;

public class CreateItemExpiryTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateItemExpiryTypeCommandHandler : ICommandHandler<CreateItemExpiryTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateItemExpiryTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateItemExpiryTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ItemExpiryType.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.ItemExpiryTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ItemExpiryTypeNotInserted);
    }
}
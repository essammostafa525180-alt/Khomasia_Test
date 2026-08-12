using Application.Abstractions;

namespace Application.CQRS.ItemType.Commands;

public class CreateItemTypeCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateItemTypeCommandHandler : ICommandHandler<CreateItemTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateItemTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateItemTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ItemType.Create(request.Code, request.Name, request.NameAr, request.Axsynced, request.IsActive);

        await _unitOfWork.ItemTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ItemTypeNotInserted);
    }
}
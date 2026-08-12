using Application.Abstractions;

namespace Application.CQRS.ToolsType.Commands;

public class CreateToolsTypeCommand : ICommand<Result<int>>
{
        public int? AssetGroupFk { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateToolsTypeCommandHandler : ICommandHandler<CreateToolsTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateToolsTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateToolsTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ToolsType.Create(request.AssetGroupFk, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.ToolsTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ToolsTypeNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.ToolsType.Commands;

public class DeleteToolsTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteToolsTypeCommandHandler : ICommandHandler<DeleteToolsTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteToolsTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteToolsTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ToolsTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ToolsTypeNotFound);

        _unitOfWork.ToolsTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ToolsTypeNotDeleted);
    }
}
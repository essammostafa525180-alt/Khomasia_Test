using Application.Abstractions;

namespace Application.CQRS.MaterialGroup.Commands;

public class DeleteMaterialGroupCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteMaterialGroupCommandHandler : ICommandHandler<DeleteMaterialGroupCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMaterialGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteMaterialGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.MaterialGroupRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.MaterialGroupNotFound);

        _unitOfWork.MaterialGroupRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.MaterialGroupNotDeleted);
    }
}
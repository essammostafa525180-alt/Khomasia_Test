using Application.Abstractions;

namespace Application.CQRS.AssetsType.Commands;

public class DeleteAssetsTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetsTypeCommandHandler : ICommandHandler<DeleteAssetsTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetsTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetsTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetsTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetsTypeNotFound);

        _unitOfWork.AssetsTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetsTypeNotDeleted);
    }
}
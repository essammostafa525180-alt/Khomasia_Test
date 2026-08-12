using Application.Abstractions;

namespace Application.CQRS.PossessionType.Commands;

public class DeletePossessionTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeletePossessionTypeCommandHandler : ICommandHandler<DeletePossessionTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePossessionTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePossessionTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PossessionTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PossessionTypeNotFound);

        _unitOfWork.PossessionTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PossessionTypeNotDeleted);
    }
}
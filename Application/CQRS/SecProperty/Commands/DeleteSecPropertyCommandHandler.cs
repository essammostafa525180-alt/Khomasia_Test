using Application.Abstractions;

namespace Application.CQRS.SecProperty.Commands;

public class DeleteSecPropertyCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecPropertyCommandHandler : ICommandHandler<DeleteSecPropertyCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecPropertyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecPropertyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecPropertyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecPropertyNotFound);

        _unitOfWork.SecPropertyRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecPropertyNotDeleted);
    }
}
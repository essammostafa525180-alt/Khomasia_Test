using Application.Abstractions;

namespace Application.CQRS.FactoryLine.Commands;

public class DeleteFactoryLineCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteFactoryLineCommandHandler : ICommandHandler<DeleteFactoryLineCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFactoryLineCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteFactoryLineCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.FactoryLineRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.FactoryLineNotFound);

        _unitOfWork.FactoryLineRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.FactoryLineNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.Factory.Commands;

public class DeleteFactoryCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteFactoryCommandHandler : ICommandHandler<DeleteFactoryCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFactoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteFactoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.FactoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.FactoryNotFound);

        _unitOfWork.FactoryRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.FactoryNotDeleted);
    }
}
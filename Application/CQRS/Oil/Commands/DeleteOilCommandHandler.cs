using Application.Abstractions;

namespace Application.CQRS.Oil.Commands;

public class DeleteOilCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteOilCommandHandler : ICommandHandler<DeleteOilCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOilCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteOilCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.OilRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.OilNotFound);

        _unitOfWork.OilRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.OilNotDeleted);
    }
}
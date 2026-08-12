using Application.Abstractions;

namespace Application.CQRS.Manufacture.Commands;

public class DeleteManufactureCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteManufactureCommandHandler : ICommandHandler<DeleteManufactureCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteManufactureCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteManufactureCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ManufactureRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ManufactureNotFound);

        _unitOfWork.ManufactureRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ManufactureNotDeleted);
    }
}
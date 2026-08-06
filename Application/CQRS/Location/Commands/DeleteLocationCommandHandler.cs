using Application.Abstractions;

namespace Application.CQRS.Location.Commands;

public class DeleteLocationCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteLocationCommandHandler : ICommandHandler<DeleteLocationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLocationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.LocationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.LocationNotFound);

        _unitOfWork.LocationRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.LocationNotDeleted);
    }
}
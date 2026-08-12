using Application.Abstractions;

namespace Application.CQRS.Sector.Commands;

public class DeleteSectorCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSectorCommandHandler : ICommandHandler<DeleteSectorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSectorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSectorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SectorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SectorNotFound);

        _unitOfWork.SectorRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SectorNotDeleted);
    }
}
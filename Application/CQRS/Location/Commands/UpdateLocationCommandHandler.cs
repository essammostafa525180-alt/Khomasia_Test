using Application.Abstractions;

namespace Application.CQRS.Location.Commands;

public class UpdateLocationCommand : ICommand<Result>
{
        public int Id { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateLocationCommandHandler : ICommandHandler<UpdateLocationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLocationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.LocationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.LocationNotFound);

        entity.Update(request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.LocationNotUpdated);
    }
}
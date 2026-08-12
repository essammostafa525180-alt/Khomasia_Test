using Application.Abstractions;

namespace Application.CQRS.AirFilterType.Commands;

public class DeleteAirFilterTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAirFilterTypeCommandHandler : ICommandHandler<DeleteAirFilterTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAirFilterTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAirFilterTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AirFilterTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AirFilterTypeNotFound);

        _unitOfWork.AirFilterTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AirFilterTypeNotDeleted);
    }
}
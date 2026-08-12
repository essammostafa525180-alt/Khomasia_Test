using Application.Abstractions;

namespace Application.CQRS.City.Commands;

public class DeleteCityCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteCityCommandHandler : ICommandHandler<DeleteCityCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.CityNotFound);

        _unitOfWork.CityRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.CityNotDeleted);
    }
}
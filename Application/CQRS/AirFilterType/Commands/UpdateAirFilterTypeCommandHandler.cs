using Application.Abstractions;

namespace Application.CQRS.AirFilterType.Commands;

public class UpdateAirFilterTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAirFilterTypeCommandHandler : ICommandHandler<UpdateAirFilterTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAirFilterTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAirFilterTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AirFilterTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AirFilterTypeNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AirFilterTypeNotUpdated);
    }
}
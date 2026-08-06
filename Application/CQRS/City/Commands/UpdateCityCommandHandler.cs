using Application.Abstractions;

namespace Application.CQRS.City.Commands;

public class UpdateCityCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? StateFk { get; set; }
        public int? RelatedProjectFk { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateCityCommandHandler : ICommandHandler<UpdateCityCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.CityNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.StateFk, request.RelatedProjectFk, request.Axsynced, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.CityNotUpdated);
    }
}
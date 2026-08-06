using Application.Abstractions;

namespace Application.CQRS.City.Commands;

public class CreateCityCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? StateFk { get; set; }
        public int? RelatedProjectFk { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateCityCommandHandler : ICommandHandler<CreateCityCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.City.Create(request.Code, request.Name, request.NameAr, request.StateFk, request.RelatedProjectFk, request.Axsynced, request.IsActive);

        await _unitOfWork.CityRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.CityNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.Country.Commands;

public class UpdateCountryCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateCountryCommandHandler : ICommandHandler<UpdateCountryCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCountryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CountryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.CountryNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.CountryNotUpdated);
    }
}
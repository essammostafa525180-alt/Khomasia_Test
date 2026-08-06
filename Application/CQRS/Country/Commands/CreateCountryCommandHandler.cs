using Application.Abstractions;

namespace Application.CQRS.Country.Commands;

public class CreateCountryCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateCountryCommandHandler : ICommandHandler<CreateCountryCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCountryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.Country.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.CountryRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.CountryNotInserted);
    }
}
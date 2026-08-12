using Application.Abstractions;

namespace Application.CQRS.Country.Commands;

public class DeleteCountryCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteCountryCommandHandler : ICommandHandler<DeleteCountryCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCountryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CountryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.CountryNotFound);

        _unitOfWork.CountryRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.CountryNotDeleted);
    }
}
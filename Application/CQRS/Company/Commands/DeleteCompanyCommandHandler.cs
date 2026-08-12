using Application.Abstractions;

namespace Application.CQRS.Company.Commands;

public class DeleteCompanyCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteCompanyCommandHandler : ICommandHandler<DeleteCompanyCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CompanyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.CompanyNotFound);

        _unitOfWork.CompanyRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.CompanyNotDeleted);
    }
}
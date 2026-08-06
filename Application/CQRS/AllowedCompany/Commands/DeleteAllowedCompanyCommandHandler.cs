using Application.Abstractions;

namespace Application.CQRS.AllowedCompany.Commands;

public class DeleteAllowedCompanyCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAllowedCompanyCommandHandler : ICommandHandler<DeleteAllowedCompanyCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAllowedCompanyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAllowedCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AllowedCompanyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AllowedCompanyNotFound);

        _unitOfWork.AllowedCompanyRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AllowedCompanyNotDeleted);
    }
}
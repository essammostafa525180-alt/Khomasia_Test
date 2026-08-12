using Application.Abstractions;

namespace Application.CQRS.AllowedCompany.Commands;

public class UpdateAllowedCompanyCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? CompanyFk { get; set; }
        public int? UserFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAllowedCompanyCommandHandler : ICommandHandler<UpdateAllowedCompanyCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAllowedCompanyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAllowedCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AllowedCompanyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AllowedCompanyNotFound);

        entity.Update(request.CompanyFk, request.UserFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AllowedCompanyNotUpdated);
    }
}
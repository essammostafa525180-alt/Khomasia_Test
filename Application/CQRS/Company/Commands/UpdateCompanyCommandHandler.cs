using Application.Abstractions;

namespace Application.CQRS.Company.Commands;

public class UpdateCompanyCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateCompanyCommandHandler : ICommandHandler<UpdateCompanyCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CompanyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.CompanyNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.CompanyNotUpdated);
    }
}
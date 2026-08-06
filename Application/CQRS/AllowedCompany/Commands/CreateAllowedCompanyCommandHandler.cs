using Application.Abstractions;

namespace Application.CQRS.AllowedCompany.Commands;

public class CreateAllowedCompanyCommand : ICommand<Result<int>>
{
        public int? CompanyFk { get; set; }
        public int? UserFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAllowedCompanyCommandHandler : ICommandHandler<CreateAllowedCompanyCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAllowedCompanyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAllowedCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.AllowedCompany.Create(request.CompanyFk, request.UserFk, request.IsActive);

        await _unitOfWork.AllowedCompanyRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AllowedCompanyNotInserted);
    }
}
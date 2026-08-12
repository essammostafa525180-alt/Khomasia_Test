using Application.Abstractions;

namespace Application.CQRS.Company.Commands;

public class CreateCompanyCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.CompanyAggregate.Company.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.CompanyRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.CompanyNotInserted);
    }
}
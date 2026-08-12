using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Company.Queries;

public class GetCompanyByIdQuery : IQuery<Result<CompanyDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetCompanyByIdQueryHandler : IQueryHandler<GetCompanyByIdQuery, Result<CompanyDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCompanyByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CompanyDetailsResponse>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CompanyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<CompanyDetailsResponse>.Failure(Errors.CompanyNotFound);

        var response = entity.Adapt<CompanyDetailsResponse>();

        return Result<CompanyDetailsResponse>.Success(response);
    }
}
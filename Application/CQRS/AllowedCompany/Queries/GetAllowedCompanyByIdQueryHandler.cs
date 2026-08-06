using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AllowedCompany.Queries;

public class GetAllowedCompanyByIdQuery : IQuery<Result<AllowedCompanyDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAllowedCompanyByIdQueryHandler : IQueryHandler<GetAllowedCompanyByIdQuery, Result<AllowedCompanyDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllowedCompanyByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AllowedCompanyDetailsResponse>> Handle(GetAllowedCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AllowedCompanyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AllowedCompanyDetailsResponse>.Failure(Errors.AllowedCompanyNotFound);

        var response = entity.Adapt<AllowedCompanyDetailsResponse>();

        return Result<AllowedCompanyDetailsResponse>.Success(response);
    }
}
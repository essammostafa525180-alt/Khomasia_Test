using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Company.Queries;

public class GetAllCompanyQuery
: IQuery<Result<PagingSortingFiltering<CompanyDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllCompanyQueryHandler :
    IQueryHandler<GetAllCompanyQuery,
        Result<PagingSortingFiltering<CompanyDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCompanyQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<CompanyDetailsResponse>>> Handle(
        GetAllCompanyQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CompanyRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<CompanyDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<CompanyDetailsResponse>>.Success(result);
    }
}
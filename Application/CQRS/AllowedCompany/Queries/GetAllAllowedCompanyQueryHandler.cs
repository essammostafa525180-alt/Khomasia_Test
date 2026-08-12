using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AllowedCompany.Queries;

public class GetAllAllowedCompanyQuery
: IQuery<Result<PagingSortingFiltering<AllowedCompanyDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAllowedCompanyQueryHandler :
    IQueryHandler<GetAllAllowedCompanyQuery,
        Result<PagingSortingFiltering<AllowedCompanyDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAllowedCompanyQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AllowedCompanyDetailsResponse>>> Handle(
        GetAllAllowedCompanyQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AllowedCompanyRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AllowedCompanyDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AllowedCompanyDetailsResponse>>.Success(result);
    }
}
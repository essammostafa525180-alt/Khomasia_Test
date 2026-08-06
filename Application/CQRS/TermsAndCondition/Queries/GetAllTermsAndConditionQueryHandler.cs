using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.TermsAndCondition.Queries;

public class GetAllTermsAndConditionQuery
: IQuery<Result<PagingSortingFiltering<TermsAndConditionDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllTermsAndConditionQueryHandler :
    IQueryHandler<GetAllTermsAndConditionQuery,
        Result<PagingSortingFiltering<TermsAndConditionDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTermsAndConditionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<TermsAndConditionDetailsResponse>>> Handle(
        GetAllTermsAndConditionQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.TermsAndConditionRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<TermsAndConditionDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<TermsAndConditionDetailsResponse>>.Success(result);
    }
}
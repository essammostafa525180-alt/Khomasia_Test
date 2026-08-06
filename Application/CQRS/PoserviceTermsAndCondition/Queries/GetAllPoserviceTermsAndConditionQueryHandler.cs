using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.PoserviceTermsAndCondition.Queries;

public class GetAllPoserviceTermsAndConditionQuery
: IQuery<Result<PagingSortingFiltering<PoserviceTermsAndConditionDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPoserviceTermsAndConditionQueryHandler :
    IQueryHandler<GetAllPoserviceTermsAndConditionQuery,
        Result<PagingSortingFiltering<PoserviceTermsAndConditionDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPoserviceTermsAndConditionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<PoserviceTermsAndConditionDetailsResponse>>> Handle(
        GetAllPoserviceTermsAndConditionQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PoserviceTermsAndConditionRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<PoserviceTermsAndConditionDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PoserviceTermsAndConditionDetailsResponse>>.Success(result);
    }
}
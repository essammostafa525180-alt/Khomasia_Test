using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecConfiguration.Queries;

public class GetAllSecConfigurationQuery
: IQuery<Result<PagingSortingFiltering<SecConfigurationDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecConfigurationQueryHandler :
    IQueryHandler<GetAllSecConfigurationQuery,
        Result<PagingSortingFiltering<SecConfigurationDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecConfigurationQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecConfigurationDetailsResponse>>> Handle(
        GetAllSecConfigurationQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecConfigurationRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecConfigurationDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecConfigurationDetailsResponse>>.Success(result);
    }
}
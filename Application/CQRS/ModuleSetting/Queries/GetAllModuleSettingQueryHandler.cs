using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ModuleSetting.Queries;

public class GetAllModuleSettingQuery
: IQuery<Result<PagingSortingFiltering<ModuleSettingDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllModuleSettingQueryHandler :
    IQueryHandler<GetAllModuleSettingQuery,
        Result<PagingSortingFiltering<ModuleSettingDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllModuleSettingQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ModuleSettingDetailsResponse>>> Handle(
        GetAllModuleSettingQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ModuleSettingRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ModuleSettingDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ModuleSettingDetailsResponse>>.Success(result);
    }
}
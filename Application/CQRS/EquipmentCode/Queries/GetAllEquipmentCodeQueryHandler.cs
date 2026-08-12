using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.EquipmentCode.Queries;

public class GetAllEquipmentCodeQuery
: IQuery<Result<PagingSortingFiltering<EquipmentCodeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllEquipmentCodeQueryHandler :
    IQueryHandler<GetAllEquipmentCodeQuery,
        Result<PagingSortingFiltering<EquipmentCodeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEquipmentCodeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<EquipmentCodeDetailsResponse>>> Handle(
        GetAllEquipmentCodeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.EquipmentCodeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<EquipmentCodeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<EquipmentCodeDetailsResponse>>.Success(result);
    }
}
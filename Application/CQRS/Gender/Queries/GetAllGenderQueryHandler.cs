using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Gender.Queries;

public class GetAllGenderQuery
: IQuery<Result<PagingSortingFiltering<GenderDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllGenderQueryHandler :
    IQueryHandler<GetAllGenderQuery,
        Result<PagingSortingFiltering<GenderDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllGenderQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<GenderDetailsResponse>>> Handle(
        GetAllGenderQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.GenderRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<GenderDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<GenderDetailsResponse>>.Success(result);
    }
}
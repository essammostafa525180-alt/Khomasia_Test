using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Contact.Queries;

public class GetAllContactQuery
: IQuery<Result<PagingSortingFiltering<ContactDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllContactQueryHandler :
    IQueryHandler<GetAllContactQuery,
        Result<PagingSortingFiltering<ContactDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllContactQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ContactDetailsResponse>>> Handle(
        GetAllContactQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ContactRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ContactDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ContactDetailsResponse>>.Success(result);
    }
}
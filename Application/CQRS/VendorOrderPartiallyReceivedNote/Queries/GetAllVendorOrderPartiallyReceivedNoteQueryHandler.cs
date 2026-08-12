using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderPartiallyReceivedNote.Queries;

public class GetAllVendorOrderPartiallyReceivedNoteQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderPartiallyReceivedNoteDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderPartiallyReceivedNoteQueryHandler :
    IQueryHandler<GetAllVendorOrderPartiallyReceivedNoteQuery,
        Result<PagingSortingFiltering<VendorOrderPartiallyReceivedNoteDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderPartiallyReceivedNoteQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderPartiallyReceivedNoteDetailsResponse>>> Handle(
        GetAllVendorOrderPartiallyReceivedNoteQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderPartiallyReceivedNoteRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderPartiallyReceivedNoteDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderPartiallyReceivedNoteDetailsResponse>>.Success(result);
    }
}
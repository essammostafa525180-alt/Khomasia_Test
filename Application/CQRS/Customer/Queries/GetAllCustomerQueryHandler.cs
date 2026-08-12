using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Customer.Queries;

public class GetAllCustomerQuery
: IQuery<Result<PagingSortingFiltering<CustomerDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllCustomerQueryHandler :
    IQueryHandler<GetAllCustomerQuery,
        Result<PagingSortingFiltering<CustomerDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCustomerQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<CustomerDetailsResponse>>> Handle(
        GetAllCustomerQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CustomerRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<CustomerDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<CustomerDetailsResponse>>.Success(result);
    }
}
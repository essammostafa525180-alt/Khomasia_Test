using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Expense.Queries;

public class GetAllExpenseQuery
: IQuery<Result<PagingSortingFiltering<ExpenseDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllExpenseQueryHandler :
    IQueryHandler<GetAllExpenseQuery,
        Result<PagingSortingFiltering<ExpenseDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllExpenseQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ExpenseDetailsResponse>>> Handle(
        GetAllExpenseQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ExpenseRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ExpenseDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ExpenseDetailsResponse>>.Success(result);
    }
}
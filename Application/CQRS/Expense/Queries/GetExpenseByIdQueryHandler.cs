using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Expense.Queries;

public class GetExpenseByIdQuery : IQuery<Result<ExpenseDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetExpenseByIdQueryHandler : IQueryHandler<GetExpenseByIdQuery, Result<ExpenseDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetExpenseByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ExpenseDetailsResponse>> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ExpenseRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ExpenseDetailsResponse>.Failure(Errors.ExpenseNotFound);

        var response = entity.Adapt<ExpenseDetailsResponse>();

        return Result<ExpenseDetailsResponse>.Success(response);
    }
}
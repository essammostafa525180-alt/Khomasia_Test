using Application.Abstractions;

namespace Application.CQRS.Expense.Commands;

public class CreateExpenseCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? CompanyFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateExpenseCommandHandler : ICommandHandler<CreateExpenseCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateExpenseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.CompanyAggregate.Expense.Create(request.Code, request.Name, request.NameAr, request.CompanyFk, request.IsActive);

        await _unitOfWork.ExpenseRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ExpenseNotInserted);
    }
}
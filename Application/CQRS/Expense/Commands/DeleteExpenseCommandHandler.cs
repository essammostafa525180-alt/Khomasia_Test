using Application.Abstractions;

namespace Application.CQRS.Expense.Commands;

public class DeleteExpenseCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteExpenseCommandHandler : ICommandHandler<DeleteExpenseCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteExpenseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ExpenseRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ExpenseNotFound);

        _unitOfWork.ExpenseRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ExpenseNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.Expense.Commands;

public class UpdateExpenseCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? CompanyFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateExpenseCommandHandler : ICommandHandler<UpdateExpenseCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateExpenseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ExpenseRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ExpenseNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.CompanyFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ExpenseNotUpdated);
    }
}
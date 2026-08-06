using Application.Abstractions;

namespace Application.CQRS.PaymentTerm.Commands;

public class DeletePaymentTermCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeletePaymentTermCommandHandler : ICommandHandler<DeletePaymentTermCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePaymentTermCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePaymentTermCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PaymentTermRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PaymentTermNotFound);

        _unitOfWork.PaymentTermRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PaymentTermNotDeleted);
    }
}
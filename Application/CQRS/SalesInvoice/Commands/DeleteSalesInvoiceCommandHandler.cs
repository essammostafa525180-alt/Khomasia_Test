using Application.Abstractions;

namespace Application.CQRS.SalesInvoice.Commands;

public class DeleteSalesInvoiceCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSalesInvoiceCommandHandler : ICommandHandler<DeleteSalesInvoiceCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSalesInvoiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSalesInvoiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SalesInvoiceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SalesInvoiceNotFound);

        _unitOfWork.SalesInvoiceRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SalesInvoiceNotDeleted);
    }
}
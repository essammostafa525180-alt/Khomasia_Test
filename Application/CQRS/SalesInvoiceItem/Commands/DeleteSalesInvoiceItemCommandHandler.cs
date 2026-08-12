using Application.Abstractions;

namespace Application.CQRS.SalesInvoiceItem.Commands;

public class DeleteSalesInvoiceItemCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSalesInvoiceItemCommandHandler : ICommandHandler<DeleteSalesInvoiceItemCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSalesInvoiceItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSalesInvoiceItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SalesInvoiceItemRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SalesInvoiceItemNotFound);

        _unitOfWork.SalesInvoiceItemRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SalesInvoiceItemNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.SalesInvoiceItem.Commands;

public class UpdateSalesInvoiceItemCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? SalesInvoiceId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetAmount { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSalesInvoiceItemCommandHandler : ICommandHandler<UpdateSalesInvoiceItemCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSalesInvoiceItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSalesInvoiceItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SalesInvoiceItemRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SalesInvoiceItemNotFound);

        entity.Update(request.SalesInvoiceId, request.ProductId, request.Quantity, request.Price, request.Discount, request.NetAmount, request.UpdatedOn, request.UpdatedBy, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SalesInvoiceItemNotUpdated);
    }
}
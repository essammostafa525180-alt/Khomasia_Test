using Application.Abstractions;

namespace Application.CQRS.SalesInvoiceItem.Commands;

public class CreateSalesInvoiceItemCommand : ICommand<Result<int>>
{
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
internal class CreateSalesInvoiceItemCommandHandler : ICommandHandler<CreateSalesInvoiceItemCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSalesInvoiceItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSalesInvoiceItemCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SalesAggregate.SalesInvoiceItem.Create(request.SalesInvoiceId, request.ProductId, request.Quantity, request.Price, request.Discount, request.NetAmount, request.UpdatedOn, request.UpdatedBy, request.IsActive);

        await _unitOfWork.SalesInvoiceItemRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SalesInvoiceItemNotInserted);
    }
}
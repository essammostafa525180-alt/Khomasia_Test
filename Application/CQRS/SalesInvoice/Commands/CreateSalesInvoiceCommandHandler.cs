using Application.Abstractions;

namespace Application.CQRS.SalesInvoice.Commands;

public class CreateSalesInvoiceCommand : ICommand<Result<int>>
{
        public int? CustomerId { get; set; }
        public int? UserId { get; set; }
        public string? Address { get; set; }
        public string? ContactPerson { get; set; }
        public decimal? Vatpercentage { get; set; }
        public decimal? Vatamount { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSalesInvoiceCommandHandler : ICommandHandler<CreateSalesInvoiceCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSalesInvoiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSalesInvoiceCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SalesAggregate.SalesInvoice.Create(request.CustomerId, request.UserId, request.Address, request.ContactPerson, request.Vatpercentage, request.Vatamount, request.TotalAmount, request.UpdatedOn, request.UpdatedBy, request.IsActive);

        await _unitOfWork.SalesInvoiceRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SalesInvoiceNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.SalesInvoice.Commands;

public class UpdateSalesInvoiceCommand : ICommand<Result>
{
        public int Id { get; set; }
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
internal class UpdateSalesInvoiceCommandHandler : ICommandHandler<UpdateSalesInvoiceCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSalesInvoiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSalesInvoiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SalesInvoiceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SalesInvoiceNotFound);

        entity.Update(request.CustomerId, request.UserId, request.Address, request.ContactPerson, request.Vatpercentage, request.Vatamount, request.TotalAmount, request.UpdatedOn, request.UpdatedBy, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SalesInvoiceNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.SalesQuotation.Commands;

public class CreateSalesQuotationCommand : ICommand<Result<int>>
{
        public int? CompanyFk { get; set; }
        public int? RequestForQuotationFk { get; set; }
        public string? OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateOnly? ExpectedDeliveryDate { get; set; }
        public int? CustomerFk { get; set; }
        public string? Notes { get; set; }
        public decimal? TotalRatio { get; set; }
        public decimal? TotalCost { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSalesQuotationCommandHandler : ICommandHandler<CreateSalesQuotationCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSalesQuotationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSalesQuotationCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SalesAggregate.SalesQuotation.Create(request.CompanyFk, request.RequestForQuotationFk, request.OrderNo, request.OrderDate, request.ExpectedDeliveryDate, request.CustomerFk, request.Notes, request.TotalRatio, request.TotalCost, request.IsActive);

        await _unitOfWork.SalesQuotationRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SalesQuotationNotInserted);
    }
}
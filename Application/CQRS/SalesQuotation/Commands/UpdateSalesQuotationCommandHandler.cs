using Application.Abstractions;

namespace Application.CQRS.SalesQuotation.Commands;

public class UpdateSalesQuotationCommand : ICommand<Result>
{
        public int Id { get; set; }
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
internal class UpdateSalesQuotationCommandHandler : ICommandHandler<UpdateSalesQuotationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSalesQuotationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSalesQuotationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SalesQuotationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SalesQuotationNotFound);

        entity.Update(request.CompanyFk, request.RequestForQuotationFk, request.OrderNo, request.OrderDate, request.ExpectedDeliveryDate, request.CustomerFk, request.Notes, request.TotalRatio, request.TotalCost, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SalesQuotationNotUpdated);
    }
}
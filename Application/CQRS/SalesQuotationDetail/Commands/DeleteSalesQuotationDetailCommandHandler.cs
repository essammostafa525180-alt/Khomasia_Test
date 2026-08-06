using Application.Abstractions;

namespace Application.CQRS.SalesQuotationDetail.Commands;

public class DeleteSalesQuotationDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSalesQuotationDetailCommandHandler : ICommandHandler<DeleteSalesQuotationDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSalesQuotationDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSalesQuotationDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SalesQuotationDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SalesQuotationDetailNotFound);

        _unitOfWork.SalesQuotationDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SalesQuotationDetailNotDeleted);
    }
}
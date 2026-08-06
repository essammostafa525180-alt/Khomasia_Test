using Application.Abstractions;

namespace Application.CQRS.SalesQuotation.Commands;

public class DeleteSalesQuotationCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSalesQuotationCommandHandler : ICommandHandler<DeleteSalesQuotationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSalesQuotationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSalesQuotationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SalesQuotationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SalesQuotationNotFound);

        _unitOfWork.SalesQuotationRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SalesQuotationNotDeleted);
    }
}
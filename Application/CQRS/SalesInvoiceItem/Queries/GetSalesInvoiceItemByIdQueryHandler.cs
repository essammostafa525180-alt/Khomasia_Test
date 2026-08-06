using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SalesInvoiceItem.Queries;

public class GetSalesInvoiceItemByIdQuery : IQuery<Result<SalesInvoiceItemDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSalesInvoiceItemByIdQueryHandler : IQueryHandler<GetSalesInvoiceItemByIdQuery, Result<SalesInvoiceItemDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSalesInvoiceItemByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SalesInvoiceItemDetailsResponse>> Handle(GetSalesInvoiceItemByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SalesInvoiceItemRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SalesInvoiceItemDetailsResponse>.Failure(Errors.SalesInvoiceItemNotFound);

        var response = entity.Adapt<SalesInvoiceItemDetailsResponse>();

        return Result<SalesInvoiceItemDetailsResponse>.Success(response);
    }
}
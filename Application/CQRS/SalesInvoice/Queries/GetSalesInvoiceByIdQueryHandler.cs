using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SalesInvoice.Queries;

public class GetSalesInvoiceByIdQuery : IQuery<Result<SalesInvoiceDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSalesInvoiceByIdQueryHandler : IQueryHandler<GetSalesInvoiceByIdQuery, Result<SalesInvoiceDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSalesInvoiceByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SalesInvoiceDetailsResponse>> Handle(GetSalesInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SalesInvoiceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SalesInvoiceDetailsResponse>.Failure(Errors.SalesInvoiceNotFound);

        var response = entity.Adapt<SalesInvoiceDetailsResponse>();

        return Result<SalesInvoiceDetailsResponse>.Success(response);
    }
}
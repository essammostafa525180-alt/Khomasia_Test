using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SalesQuotation.Queries;

public class GetSalesQuotationByIdQuery : IQuery<Result<SalesQuotationDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSalesQuotationByIdQueryHandler : IQueryHandler<GetSalesQuotationByIdQuery, Result<SalesQuotationDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSalesQuotationByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SalesQuotationDetailsResponse>> Handle(GetSalesQuotationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SalesQuotationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SalesQuotationDetailsResponse>.Failure(Errors.SalesQuotationNotFound);

        var response = entity.Adapt<SalesQuotationDetailsResponse>();

        return Result<SalesQuotationDetailsResponse>.Success(response);
    }
}
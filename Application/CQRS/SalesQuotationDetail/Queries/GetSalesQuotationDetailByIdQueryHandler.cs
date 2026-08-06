using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SalesQuotationDetail.Queries;

public class GetSalesQuotationDetailByIdQuery : IQuery<Result<SalesQuotationDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSalesQuotationDetailByIdQueryHandler : IQueryHandler<GetSalesQuotationDetailByIdQuery, Result<SalesQuotationDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSalesQuotationDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SalesQuotationDetailDetailsResponse>> Handle(GetSalesQuotationDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SalesQuotationDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SalesQuotationDetailDetailsResponse>.Failure(Errors.SalesQuotationDetailNotFound);

        var response = entity.Adapt<SalesQuotationDetailDetailsResponse>();

        return Result<SalesQuotationDetailDetailsResponse>.Success(response);
    }
}
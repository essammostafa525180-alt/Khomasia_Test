using Application.Abstractions;
using Mapster;

namespace Application.CQRS.PaymentTerm.Queries;

public class GetPaymentTermByIdQuery : IQuery<Result<PaymentTermDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetPaymentTermByIdQueryHandler : IQueryHandler<GetPaymentTermByIdQuery, Result<PaymentTermDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPaymentTermByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PaymentTermDetailsResponse>> Handle(GetPaymentTermByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PaymentTermRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<PaymentTermDetailsResponse>.Failure(Errors.PaymentTermNotFound);

        var response = entity.Adapt<PaymentTermDetailsResponse>();

        return Result<PaymentTermDetailsResponse>.Success(response);
    }
}
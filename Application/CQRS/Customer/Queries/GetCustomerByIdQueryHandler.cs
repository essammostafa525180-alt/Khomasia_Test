using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Customer.Queries;

public class GetCustomerByIdQuery : IQuery<Result<CustomerDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetCustomerByIdQueryHandler : IQueryHandler<GetCustomerByIdQuery, Result<CustomerDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CustomerDetailsResponse>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<CustomerDetailsResponse>.Failure(Errors.CustomerNotFound);

        var response = entity.Adapt<CustomerDetailsResponse>();

        return Result<CustomerDetailsResponse>.Success(response);
    }
}
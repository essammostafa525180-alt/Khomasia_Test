using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ServiceType.Queries;

public class GetServiceTypeByIdQuery : IQuery<Result<ServiceTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetServiceTypeByIdQueryHandler : IQueryHandler<GetServiceTypeByIdQuery, Result<ServiceTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetServiceTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ServiceTypeDetailsResponse>> Handle(GetServiceTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ServiceTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ServiceTypeDetailsResponse>.Failure(Errors.ServiceTypeNotFound);

        var response = entity.Adapt<ServiceTypeDetailsResponse>();

        return Result<ServiceTypeDetailsResponse>.Success(response);
    }
}
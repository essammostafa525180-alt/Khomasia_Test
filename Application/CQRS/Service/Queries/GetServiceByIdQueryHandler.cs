using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Service.Queries;

public class GetServiceByIdQuery : IQuery<Result<ServiceDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetServiceByIdQueryHandler : IQueryHandler<GetServiceByIdQuery, Result<ServiceDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetServiceByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ServiceDetailsResponse>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ServiceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ServiceDetailsResponse>.Failure(Errors.ServiceNotFound);

        var response = entity.Adapt<ServiceDetailsResponse>();

        return Result<ServiceDetailsResponse>.Success(response);
    }
}
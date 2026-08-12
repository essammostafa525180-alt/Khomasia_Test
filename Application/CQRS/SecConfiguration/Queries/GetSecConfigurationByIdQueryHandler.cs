using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecConfiguration.Queries;

public class GetSecConfigurationByIdQuery : IQuery<Result<SecConfigurationDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecConfigurationByIdQueryHandler : IQueryHandler<GetSecConfigurationByIdQuery, Result<SecConfigurationDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecConfigurationByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecConfigurationDetailsResponse>> Handle(GetSecConfigurationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecConfigurationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecConfigurationDetailsResponse>.Failure(Errors.SecConfigurationNotFound);

        var response = entity.Adapt<SecConfigurationDetailsResponse>();

        return Result<SecConfigurationDetailsResponse>.Success(response);
    }
}
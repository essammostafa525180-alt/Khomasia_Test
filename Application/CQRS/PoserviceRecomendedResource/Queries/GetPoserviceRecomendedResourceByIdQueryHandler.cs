using Application.Abstractions;
using Mapster;

namespace Application.CQRS.PoserviceRecomendedResource.Queries;

public class GetPoserviceRecomendedResourceByIdQuery : IQuery<Result<PoserviceRecomendedResourceDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetPoserviceRecomendedResourceByIdQueryHandler : IQueryHandler<GetPoserviceRecomendedResourceByIdQuery, Result<PoserviceRecomendedResourceDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPoserviceRecomendedResourceByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PoserviceRecomendedResourceDetailsResponse>> Handle(GetPoserviceRecomendedResourceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceRecomendedResourceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<PoserviceRecomendedResourceDetailsResponse>.Failure(Errors.PoserviceRecomendedResourceNotFound);

        var response = entity.Adapt<PoserviceRecomendedResourceDetailsResponse>();

        return Result<PoserviceRecomendedResourceDetailsResponse>.Success(response);
    }
}
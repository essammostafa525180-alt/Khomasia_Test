using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ServiceMainCategory.Queries;

public class GetServiceMainCategoryByIdQuery : IQuery<Result<ServiceMainCategoryDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetServiceMainCategoryByIdQueryHandler : IQueryHandler<GetServiceMainCategoryByIdQuery, Result<ServiceMainCategoryDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetServiceMainCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ServiceMainCategoryDetailsResponse>> Handle(GetServiceMainCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ServiceMainCategoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ServiceMainCategoryDetailsResponse>.Failure(Errors.ServiceMainCategoryNotFound);

        var response = entity.Adapt<ServiceMainCategoryDetailsResponse>();

        return Result<ServiceMainCategoryDetailsResponse>.Success(response);
    }
}
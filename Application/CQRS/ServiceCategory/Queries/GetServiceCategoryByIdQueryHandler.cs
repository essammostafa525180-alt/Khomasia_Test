using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ServiceCategory.Queries;

public class GetServiceCategoryByIdQuery : IQuery<Result<ServiceCategoryDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetServiceCategoryByIdQueryHandler : IQueryHandler<GetServiceCategoryByIdQuery, Result<ServiceCategoryDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetServiceCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ServiceCategoryDetailsResponse>> Handle(GetServiceCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ServiceCategoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ServiceCategoryDetailsResponse>.Failure(Errors.ServiceCategoryNotFound);

        var response = entity.Adapt<ServiceCategoryDetailsResponse>();

        return Result<ServiceCategoryDetailsResponse>.Success(response);
    }
}
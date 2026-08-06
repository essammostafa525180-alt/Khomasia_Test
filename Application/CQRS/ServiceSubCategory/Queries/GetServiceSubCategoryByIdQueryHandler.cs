using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ServiceSubCategory.Queries;

public class GetServiceSubCategoryByIdQuery : IQuery<Result<ServiceSubCategoryDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetServiceSubCategoryByIdQueryHandler : IQueryHandler<GetServiceSubCategoryByIdQuery, Result<ServiceSubCategoryDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetServiceSubCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ServiceSubCategoryDetailsResponse>> Handle(GetServiceSubCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ServiceSubCategoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ServiceSubCategoryDetailsResponse>.Failure(Errors.ServiceSubCategoryNotFound);

        var response = entity.Adapt<ServiceSubCategoryDetailsResponse>();

        return Result<ServiceSubCategoryDetailsResponse>.Success(response);
    }
}
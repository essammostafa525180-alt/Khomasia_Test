using Application.Abstractions;
using Mapster;

namespace Application.CQRS.PoserviceTermsAndCondition.Queries;

public class GetPoserviceTermsAndConditionByIdQuery : IQuery<Result<PoserviceTermsAndConditionDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetPoserviceTermsAndConditionByIdQueryHandler : IQueryHandler<GetPoserviceTermsAndConditionByIdQuery, Result<PoserviceTermsAndConditionDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPoserviceTermsAndConditionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PoserviceTermsAndConditionDetailsResponse>> Handle(GetPoserviceTermsAndConditionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceTermsAndConditionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<PoserviceTermsAndConditionDetailsResponse>.Failure(Errors.PoserviceTermsAndConditionNotFound);

        var response = entity.Adapt<PoserviceTermsAndConditionDetailsResponse>();

        return Result<PoserviceTermsAndConditionDetailsResponse>.Success(response);
    }
}
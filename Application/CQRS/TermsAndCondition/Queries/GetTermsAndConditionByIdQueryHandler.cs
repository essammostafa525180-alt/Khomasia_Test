using Application.Abstractions;
using Mapster;

namespace Application.CQRS.TermsAndCondition.Queries;

public class GetTermsAndConditionByIdQuery : IQuery<Result<TermsAndConditionDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetTermsAndConditionByIdQueryHandler : IQueryHandler<GetTermsAndConditionByIdQuery, Result<TermsAndConditionDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTermsAndConditionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<TermsAndConditionDetailsResponse>> Handle(GetTermsAndConditionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TermsAndConditionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<TermsAndConditionDetailsResponse>.Failure(Errors.TermsAndConditionNotFound);

        var response = entity.Adapt<TermsAndConditionDetailsResponse>();

        return Result<TermsAndConditionDetailsResponse>.Success(response);
    }
}
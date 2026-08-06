using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SubSection.Queries;

public class GetSubSectionByIdQuery : IQuery<Result<SubSectionDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSubSectionByIdQueryHandler : IQueryHandler<GetSubSectionByIdQuery, Result<SubSectionDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSubSectionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SubSectionDetailsResponse>> Handle(GetSubSectionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SubSectionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SubSectionDetailsResponse>.Failure(Errors.SubSectionNotFound);

        var response = entity.Adapt<SubSectionDetailsResponse>();

        return Result<SubSectionDetailsResponse>.Success(response);
    }
}
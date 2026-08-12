using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Section.Queries;

public class GetSectionByIdQuery : IQuery<Result<SectionDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSectionByIdQueryHandler : IQueryHandler<GetSectionByIdQuery, Result<SectionDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSectionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SectionDetailsResponse>> Handle(GetSectionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SectionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SectionDetailsResponse>.Failure(Errors.SectionNotFound);

        var response = entity.Adapt<SectionDetailsResponse>();

        return Result<SectionDetailsResponse>.Success(response);
    }
}
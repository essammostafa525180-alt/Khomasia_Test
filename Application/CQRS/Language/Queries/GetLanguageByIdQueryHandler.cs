using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Language.Queries;

public class GetLanguageByIdQuery : IQuery<Result<LanguageDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetLanguageByIdQueryHandler : IQueryHandler<GetLanguageByIdQuery, Result<LanguageDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLanguageByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<LanguageDetailsResponse>> Handle(GetLanguageByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.LanguageRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<LanguageDetailsResponse>.Failure(Errors.LanguageNotFound);

        var response = entity.Adapt<LanguageDetailsResponse>();

        return Result<LanguageDetailsResponse>.Success(response);
    }
}
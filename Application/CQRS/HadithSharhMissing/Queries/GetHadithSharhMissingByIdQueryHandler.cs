using Application.Abstractions;
using Mapster;

namespace Application.CQRS.HadithSharhMissing.Queries;

public class GetHadithSharhMissingByIdQuery : IQuery<Result<HadithSharhMissingDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetHadithSharhMissingByIdQueryHandler : IQueryHandler<GetHadithSharhMissingByIdQuery, Result<HadithSharhMissingDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetHadithSharhMissingByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<HadithSharhMissingDetailsResponse>> Handle(GetHadithSharhMissingByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.HadithSharhMissingRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<HadithSharhMissingDetailsResponse>.Failure(Errors.HadithSharhMissingNotFound);

        var response = entity.Adapt<HadithSharhMissingDetailsResponse>();

        return Result<HadithSharhMissingDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecViewAction.Queries;

public class GetSecViewActionByIdQuery : IQuery<Result<SecViewActionDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecViewActionByIdQueryHandler : IQueryHandler<GetSecViewActionByIdQuery, Result<SecViewActionDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecViewActionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecViewActionDetailsResponse>> Handle(GetSecViewActionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecViewActionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecViewActionDetailsResponse>.Failure(Errors.SecViewActionNotFound);

        var response = entity.Adapt<SecViewActionDetailsResponse>();

        return Result<SecViewActionDetailsResponse>.Success(response);
    }
}
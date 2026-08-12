using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecView.Queries;

public class GetSecViewByIdQuery : IQuery<Result<SecViewDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecViewByIdQueryHandler : IQueryHandler<GetSecViewByIdQuery, Result<SecViewDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecViewByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecViewDetailsResponse>> Handle(GetSecViewByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecViewRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecViewDetailsResponse>.Failure(Errors.SecViewNotFound);

        var response = entity.Adapt<SecViewDetailsResponse>();

        return Result<SecViewDetailsResponse>.Success(response);
    }
}
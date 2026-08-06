using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Shelf.Queries;

public class GetShelfByIdQuery : IQuery<Result<ShelfDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetShelfByIdQueryHandler : IQueryHandler<GetShelfByIdQuery, Result<ShelfDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetShelfByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ShelfDetailsResponse>> Handle(GetShelfByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ShelfRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ShelfDetailsResponse>.Failure(Errors.ShelfNotFound);

        var response = entity.Adapt<ShelfDetailsResponse>();

        return Result<ShelfDetailsResponse>.Success(response);
    }
}
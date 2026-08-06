using Application.Abstractions;
using Mapster;

namespace Application.CQRS.RwPickedQuantity.Queries;

public class GetRwPickedQuantityByIdQuery : IQuery<Result<RwPickedQuantityDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetRwPickedQuantityByIdQueryHandler : IQueryHandler<GetRwPickedQuantityByIdQuery, Result<RwPickedQuantityDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRwPickedQuantityByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<RwPickedQuantityDetailsResponse>> Handle(GetRwPickedQuantityByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwPickedQuantityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<RwPickedQuantityDetailsResponse>.Failure(Errors.RwPickedQuantityNotFound);

        var response = entity.Adapt<RwPickedQuantityDetailsResponse>();

        return Result<RwPickedQuantityDetailsResponse>.Success(response);
    }
}
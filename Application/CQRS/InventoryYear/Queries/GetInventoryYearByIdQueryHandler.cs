using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryYear.Queries;

public class GetInventoryYearByIdQuery : IQuery<Result<InventoryYearDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryYearByIdQueryHandler : IQueryHandler<GetInventoryYearByIdQuery, Result<InventoryYearDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryYearByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryYearDetailsResponse>> Handle(GetInventoryYearByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryYearRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryYearDetailsResponse>.Failure(Errors.InventoryYearNotFound);

        var response = entity.Adapt<InventoryYearDetailsResponse>();

        return Result<InventoryYearDetailsResponse>.Success(response);
    }
}
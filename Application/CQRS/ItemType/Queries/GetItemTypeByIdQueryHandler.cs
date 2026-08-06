using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ItemType.Queries;

public class GetItemTypeByIdQuery : IQuery<Result<ItemTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetItemTypeByIdQueryHandler : IQueryHandler<GetItemTypeByIdQuery, Result<ItemTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetItemTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ItemTypeDetailsResponse>> Handle(GetItemTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ItemTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ItemTypeDetailsResponse>.Failure(Errors.ItemTypeNotFound);

        var response = entity.Adapt<ItemTypeDetailsResponse>();

        return Result<ItemTypeDetailsResponse>.Success(response);
    }
}
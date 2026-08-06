using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ItemExpiryType.Queries;

public class GetItemExpiryTypeByIdQuery : IQuery<Result<ItemExpiryTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetItemExpiryTypeByIdQueryHandler : IQueryHandler<GetItemExpiryTypeByIdQuery, Result<ItemExpiryTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetItemExpiryTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ItemExpiryTypeDetailsResponse>> Handle(GetItemExpiryTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ItemExpiryTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ItemExpiryTypeDetailsResponse>.Failure(Errors.ItemExpiryTypeNotFound);

        var response = entity.Adapt<ItemExpiryTypeDetailsResponse>();

        return Result<ItemExpiryTypeDetailsResponse>.Success(response);
    }
}
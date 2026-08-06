using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ItemQuantityType.Queries;

public class GetItemQuantityTypeByIdQuery : IQuery<Result<ItemQuantityTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetItemQuantityTypeByIdQueryHandler : IQueryHandler<GetItemQuantityTypeByIdQuery, Result<ItemQuantityTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetItemQuantityTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ItemQuantityTypeDetailsResponse>> Handle(GetItemQuantityTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ItemQuantityTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ItemQuantityTypeDetailsResponse>.Failure(Errors.ItemQuantityTypeNotFound);

        var response = entity.Adapt<ItemQuantityTypeDetailsResponse>();

        return Result<ItemQuantityTypeDetailsResponse>.Success(response);
    }
}
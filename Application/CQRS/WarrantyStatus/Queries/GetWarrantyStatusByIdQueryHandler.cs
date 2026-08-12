using Application.Abstractions;
using Mapster;

namespace Application.CQRS.WarrantyStatus.Queries;

public class GetWarrantyStatusByIdQuery : IQuery<Result<WarrantyStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetWarrantyStatusByIdQueryHandler : IQueryHandler<GetWarrantyStatusByIdQuery, Result<WarrantyStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetWarrantyStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<WarrantyStatusDetailsResponse>> Handle(GetWarrantyStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WarrantyStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<WarrantyStatusDetailsResponse>.Failure(Errors.WarrantyStatusNotFound);

        var response = entity.Adapt<WarrantyStatusDetailsResponse>();

        return Result<WarrantyStatusDetailsResponse>.Success(response);
    }
}
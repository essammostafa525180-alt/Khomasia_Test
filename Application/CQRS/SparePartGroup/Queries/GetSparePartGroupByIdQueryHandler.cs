using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SparePartGroup.Queries;

public class GetSparePartGroupByIdQuery : IQuery<Result<SparePartGroupDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSparePartGroupByIdQueryHandler : IQueryHandler<GetSparePartGroupByIdQuery, Result<SparePartGroupDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSparePartGroupByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SparePartGroupDetailsResponse>> Handle(GetSparePartGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SparePartGroupRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SparePartGroupDetailsResponse>.Failure(Errors.SparePartGroupNotFound);

        var response = entity.Adapt<SparePartGroupDetailsResponse>();

        return Result<SparePartGroupDetailsResponse>.Success(response);
    }
}
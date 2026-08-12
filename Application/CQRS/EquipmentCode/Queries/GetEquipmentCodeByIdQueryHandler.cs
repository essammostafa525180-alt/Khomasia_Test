using Application.Abstractions;
using Mapster;

namespace Application.CQRS.EquipmentCode.Queries;

public class GetEquipmentCodeByIdQuery : IQuery<Result<EquipmentCodeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetEquipmentCodeByIdQueryHandler : IQueryHandler<GetEquipmentCodeByIdQuery, Result<EquipmentCodeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEquipmentCodeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<EquipmentCodeDetailsResponse>> Handle(GetEquipmentCodeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.EquipmentCodeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<EquipmentCodeDetailsResponse>.Failure(Errors.EquipmentCodeNotFound);

        var response = entity.Adapt<EquipmentCodeDetailsResponse>();

        return Result<EquipmentCodeDetailsResponse>.Success(response);
    }
}
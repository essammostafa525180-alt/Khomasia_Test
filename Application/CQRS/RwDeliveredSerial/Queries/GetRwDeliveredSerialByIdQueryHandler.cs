using Application.Abstractions;
using Mapster;

namespace Application.CQRS.RwDeliveredSerial.Queries;

public class GetRwDeliveredSerialByIdQuery : IQuery<Result<RwDeliveredSerialDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetRwDeliveredSerialByIdQueryHandler : IQueryHandler<GetRwDeliveredSerialByIdQuery, Result<RwDeliveredSerialDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRwDeliveredSerialByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<RwDeliveredSerialDetailsResponse>> Handle(GetRwDeliveredSerialByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwDeliveredSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<RwDeliveredSerialDetailsResponse>.Failure(Errors.RwDeliveredSerialNotFound);

        var response = entity.Adapt<RwDeliveredSerialDetailsResponse>();

        return Result<RwDeliveredSerialDetailsResponse>.Success(response);
    }
}
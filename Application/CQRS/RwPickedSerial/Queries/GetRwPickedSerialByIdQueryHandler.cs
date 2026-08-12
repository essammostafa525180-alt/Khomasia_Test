using Application.Abstractions;
using Mapster;

namespace Application.CQRS.RwPickedSerial.Queries;

public class GetRwPickedSerialByIdQuery : IQuery<Result<RwPickedSerialDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetRwPickedSerialByIdQueryHandler : IQueryHandler<GetRwPickedSerialByIdQuery, Result<RwPickedSerialDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRwPickedSerialByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<RwPickedSerialDetailsResponse>> Handle(GetRwPickedSerialByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwPickedSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<RwPickedSerialDetailsResponse>.Failure(Errors.RwPickedSerialNotFound);

        var response = entity.Adapt<RwPickedSerialDetailsResponse>();

        return Result<RwPickedSerialDetailsResponse>.Success(response);
    }
}
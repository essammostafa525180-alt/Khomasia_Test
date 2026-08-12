using Application.Abstractions;
using Mapster;

namespace Application.CQRS.TransmissionType.Queries;

public class GetTransmissionTypeByIdQuery : IQuery<Result<TransmissionTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetTransmissionTypeByIdQueryHandler : IQueryHandler<GetTransmissionTypeByIdQuery, Result<TransmissionTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTransmissionTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<TransmissionTypeDetailsResponse>> Handle(GetTransmissionTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TransmissionTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<TransmissionTypeDetailsResponse>.Failure(Errors.TransmissionTypeNotFound);

        var response = entity.Adapt<TransmissionTypeDetailsResponse>();

        return Result<TransmissionTypeDetailsResponse>.Success(response);
    }
}
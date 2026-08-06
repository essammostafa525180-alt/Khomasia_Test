using Application.Abstractions;
using Mapster;

namespace Application.CQRS.RequestWithdrawSerial.Queries;

public class GetRequestWithdrawSerialByIdQuery : IQuery<Result<RequestWithdrawSerialDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetRequestWithdrawSerialByIdQueryHandler : IQueryHandler<GetRequestWithdrawSerialByIdQuery, Result<RequestWithdrawSerialDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRequestWithdrawSerialByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<RequestWithdrawSerialDetailsResponse>> Handle(GetRequestWithdrawSerialByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RequestWithdrawSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<RequestWithdrawSerialDetailsResponse>.Failure(Errors.RequestWithdrawSerialNotFound);

        var response = entity.Adapt<RequestWithdrawSerialDetailsResponse>();

        return Result<RequestWithdrawSerialDetailsResponse>.Success(response);
    }
}
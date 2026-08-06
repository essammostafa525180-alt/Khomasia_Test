using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ReturnReason.Queries;

public class GetReturnReasonByIdQuery : IQuery<Result<ReturnReasonDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetReturnReasonByIdQueryHandler : IQueryHandler<GetReturnReasonByIdQuery, Result<ReturnReasonDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetReturnReasonByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ReturnReasonDetailsResponse>> Handle(GetReturnReasonByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ReturnReasonRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ReturnReasonDetailsResponse>.Failure(Errors.ReturnReasonNotFound);

        var response = entity.Adapt<ReturnReasonDetailsResponse>();

        return Result<ReturnReasonDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ReturnStatus.Queries;

public class GetReturnStatusByIdQuery : IQuery<Result<ReturnStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetReturnStatusByIdQueryHandler : IQueryHandler<GetReturnStatusByIdQuery, Result<ReturnStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetReturnStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ReturnStatusDetailsResponse>> Handle(GetReturnStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ReturnStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ReturnStatusDetailsResponse>.Failure(Errors.ReturnStatusNotFound);

        var response = entity.Adapt<ReturnStatusDetailsResponse>();

        return Result<ReturnStatusDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.State.Queries;

public class GetStateByIdQuery : IQuery<Result<StateDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetStateByIdQueryHandler : IQueryHandler<GetStateByIdQuery, Result<StateDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetStateByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<StateDetailsResponse>> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StateRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<StateDetailsResponse>.Failure(Errors.StateNotFound);

        var response = entity.Adapt<StateDetailsResponse>();

        return Result<StateDetailsResponse>.Success(response);
    }
}
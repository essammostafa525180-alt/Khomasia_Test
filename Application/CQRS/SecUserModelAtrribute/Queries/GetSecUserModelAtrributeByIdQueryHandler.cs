using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecUserModelAtrribute.Queries;

public class GetSecUserModelAtrributeByIdQuery : IQuery<Result<SecUserModelAtrributeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecUserModelAtrributeByIdQueryHandler : IQueryHandler<GetSecUserModelAtrributeByIdQuery, Result<SecUserModelAtrributeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecUserModelAtrributeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecUserModelAtrributeDetailsResponse>> Handle(GetSecUserModelAtrributeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecUserModelAtrributeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecUserModelAtrributeDetailsResponse>.Failure(Errors.SecUserModelAtrributeNotFound);

        var response = entity.Adapt<SecUserModelAtrributeDetailsResponse>();

        return Result<SecUserModelAtrributeDetailsResponse>.Success(response);
    }
}
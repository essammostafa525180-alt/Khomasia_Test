using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecUserModule.Queries;

public class GetSecUserModuleByIdQuery : IQuery<Result<SecUserModuleDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecUserModuleByIdQueryHandler : IQueryHandler<GetSecUserModuleByIdQuery, Result<SecUserModuleDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecUserModuleByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecUserModuleDetailsResponse>> Handle(GetSecUserModuleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecUserModuleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecUserModuleDetailsResponse>.Failure(Errors.SecUserModuleNotFound);

        var response = entity.Adapt<SecUserModuleDetailsResponse>();

        return Result<SecUserModuleDetailsResponse>.Success(response);
    }
}
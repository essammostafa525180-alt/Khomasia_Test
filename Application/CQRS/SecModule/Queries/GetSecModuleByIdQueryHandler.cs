using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecModule.Queries;

public class GetSecModuleByIdQuery : IQuery<Result<SecModuleDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecModuleByIdQueryHandler : IQueryHandler<GetSecModuleByIdQuery, Result<SecModuleDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecModuleByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecModuleDetailsResponse>> Handle(GetSecModuleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecModuleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecModuleDetailsResponse>.Failure(Errors.SecModuleNotFound);

        var response = entity.Adapt<SecModuleDetailsResponse>();

        return Result<SecModuleDetailsResponse>.Success(response);
    }
}
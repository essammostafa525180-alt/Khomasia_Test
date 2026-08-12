using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SysKeyValue.Queries;

public class GetSysKeyValueByIdQuery : IQuery<Result<SysKeyValueDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSysKeyValueByIdQueryHandler : IQueryHandler<GetSysKeyValueByIdQuery, Result<SysKeyValueDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSysKeyValueByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SysKeyValueDetailsResponse>> Handle(GetSysKeyValueByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SysKeyValueRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SysKeyValueDetailsResponse>.Failure(Errors.SysKeyValueNotFound);

        var response = entity.Adapt<SysKeyValueDetailsResponse>();

        return Result<SysKeyValueDetailsResponse>.Success(response);
    }
}
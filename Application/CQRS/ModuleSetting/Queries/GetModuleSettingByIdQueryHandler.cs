using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ModuleSetting.Queries;

public class GetModuleSettingByIdQuery : IQuery<Result<ModuleSettingDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetModuleSettingByIdQueryHandler : IQueryHandler<GetModuleSettingByIdQuery, Result<ModuleSettingDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetModuleSettingByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ModuleSettingDetailsResponse>> Handle(GetModuleSettingByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ModuleSettingRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ModuleSettingDetailsResponse>.Failure(Errors.ModuleSettingNotFound);

        var response = entity.Adapt<ModuleSettingDetailsResponse>();

        return Result<ModuleSettingDetailsResponse>.Success(response);
    }
}